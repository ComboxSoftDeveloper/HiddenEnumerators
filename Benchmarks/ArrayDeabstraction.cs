using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace HiddenEnumerators.Benchmarks;

/// <summary>
/// История №2: foreach по массиву через IEnumerable&lt;int&gt;.
/// В .NET 8/9 - аллокация энумератора SZGenericArrayEnumerator на куче на каждый вызов.
/// В .NET 10 JIT научился девиртуализировать интерфейсные методы массивов,
/// заинлайнить энумератор и разместить его на стеке (escape analysis + GDV).
///
/// Пруфы:
///   https://github.com/dotnet/runtime/issues/108913 (план деабстракции .NET 10)
///   https://github.com/dotnet/runtime/pull/108153  (девиртуализация интерфейсных методов массивов)
///   https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/runtime
///
/// Отдельный прикол - пустой массив. Для него конструктор энумератора не создаёт
/// новый объект, а возвращает статический синглтон (старая оптимизация "не аллоцируй
/// зря"). Из-за этого JIT в точке использования не знает, какой именно объект
/// итерирует, и это мешало escape analysis. Оптимизация против оптимизации.
/// </summary>
[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0, baseline: true)]
public class ArrayDeabstraction
{
    private readonly int[] _array = Enumerable.Range(0, 512).ToArray();
    private readonly int[] _empty = [];

    // Эталон: foreach по массиву напрямую. Компилятор разворачивает в for по индексу.
    // Ноль аллокаций на любом рантайме, интерфейсы не участвуют вообще.
    [Benchmark(Baseline = true)]
    public int Array_Direct()
    {
        int sum = 0;
        foreach (int i in _array)
        {
            sum += i;
        }

        return sum;
    }

    // Главный подопытный: тот же массив, но через переменную интерфейсного типа.
    // Тут foreach обязан получить энумератор через IEnumerable<int>.GetEnumerator(),
    // а это объект на куче. Смотрим, на каком рантайме колонка Allocated обнулится.
    [Benchmark]
    public int Array_AsIEnumerable()
    {
        int sum = 0;

        IEnumerable<int> items = _array;
        foreach (int i in items)
        {
            sum += i;
        }

        return sum;
    }

    // Через невиртуальный метод-хелпер, как в примере Стивена Тауба из блога
    // "Performance Improvements in .NET 10": PGO видит, что сюда всегда приходит int[],
    // делает специализированную ветку и стек-аллоцирует энумератор.
    [Benchmark]
    public int Array_ViaHelper() => Sum(_array);

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int Sum(IEnumerable<int> values)
    {
        int sum = 0;
        foreach (int i in values)
        {
            sum += i;
        }

        return sum;
    }

    // Пустой массив через интерфейс: сюда прилетает синглтон-энумератор.
    // Аллокаций нет и не было (синглтон!), но именно этот случай исторически
    // ломал escape analysis для НЕпустых массивов - см. issue 108913.
    [Benchmark]
    public int EmptyArray_AsIEnumerable()
    {
        int sum = 0;

        IEnumerable<int> items = _empty;
        foreach (int i in items)
        {
            sum += i;
        }

        return sum;
    }
}
