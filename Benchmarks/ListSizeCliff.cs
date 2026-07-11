using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace HiddenEnumerators.Benchmarks;

/// <summary>
/// История №3: оптимизация, которая исчезает с ростом коллекции.
///
/// В .NET 10 foreach по List&lt;int&gt; через IEnumerable&lt;int&gt; часто перестал аллоцировать:
/// энумератор стек-аллоцируется благодаря PGO + escape analysis.
/// Но у магии есть граница. Стивен Тауб в "Performance Improvements in .NET 10"
/// прямо описывает два обрыва:
///
///   1) На длинных списках метод MoveNextRare выглядит для профиля "холодным",
///      не инлайнится, и энумератор "убегает" - стек-аллокация срывается.
///   2) На длинных циклах включается OSR (компиляция посреди выполнения),
///      а OSR-методы не собирают PGO-инструментацию для хвоста метода,
///      где зовётся Dispose энумератора - и девиртуализация не срабатывает.
///
/// Пруф: https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-10/
///
/// Итог: один и тот же код, но Allocated зависит от РАЗМЕРА списка.
/// Гоняем на трёх размерах и трёх рантаймах и смотрим, где обрыв.
/// </summary>
[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0, baseline: true)]
public class ListSizeCliff
{
    [Params(10, 1_000, 1_000_000)]
    public int Size { get; set; }

    private List<int> _list = null!;

    [GlobalSetup]
    public void Setup()
    {
        _list = Enumerable.Range(0, Size).ToList();
    }

    // Эталон: foreach по List напрямую - struct-энумератор, ноль аллокаций везде.
    [Benchmark(Baseline = true)]
    public long List_Direct()
    {
        long sum = 0;
        foreach (int i in _list)
        {
            sum += i;
        }

        return sum;
    }

    // Подопытный: тот же список через интерфейс.
    // .NET 8/9: 40 B на вызов на любом размере.
    // .NET 10: ожидаем 0 B на маленьких размерах и возврат аллокации на большом.
    [Benchmark]
    public long List_AsIEnumerable()
    {
        long sum = 0;

        IEnumerable<int> items = _list;
        foreach (int i in items)
        {
            sum += i;
        }

        return sum;
    }

    // Тот же сценарий, но через отдельный метод, чтобы PGO собирал профиль
    // именно по этому колл-сайту (так устроен пример из блога .NET).
    [Benchmark]
    public long List_ViaHelper() => Sum(_list);

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long Sum(IEnumerable<int> values)
    {
        long sum = 0;
        foreach (int i in values)
        {
            sum += i;
        }

        return sum;
    }
}
