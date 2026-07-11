using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace HiddenEnumerators.Benchmarks;

/// <summary>
/// История №1: SortedList аллоцирует энумератор на куче, а Dictionary - нет.
/// Пруф: https://github.com/dotnet/runtime/issues/81128
///
/// Причина в одной строчке сигнатуры:
///   Dictionary.GetEnumerator() возвращает Dictionary&lt;K,V&gt;.Enumerator (struct как есть)
///   SortedList.GetEnumerator() возвращает IEnumerator&lt;KeyValuePair&lt;K,V&gt;&gt; (struct боксится)
///
/// foreach по Dictionary берёт struct напрямую - 0 байт.
/// foreach по SortedList получает struct, упакованный в объект на куче - аллокация на каждый foreach.
///
/// Интрига: чинит ли это escape analysis в .NET 10? Запускаем на трёх рантаймах и смотрим.
/// </summary>
[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0, baseline: true)]
public class SortedListVsDictionary
{
    private readonly SortedList<int, int> _sortedList = new();
    private readonly Dictionary<int, int> _dictionary = new();

    // 15 элементов - как у автора issue #81128, он мерял ровно свой продовый размер
    [GlobalSetup]
    public void Setup()
    {
        for (int i = 0; i < 15; i++)
        {
            _sortedList.Add(i, i);
            _dictionary.Add(i, i);
        }
    }

    [Benchmark(Baseline = true)]
    public int Dictionary_Foreach()
    {
        int sum = 0;
        foreach (KeyValuePair<int, int> pair in _dictionary)
        {
            sum += pair.Value;
        }

        return sum;
    }

    [Benchmark]
    public int SortedList_Foreach()
    {
        int sum = 0;
        foreach (KeyValuePair<int, int> pair in _sortedList)
        {
            sum += pair.Value;
        }

        return sum;
    }

    // Контрольный выстрел: тот же Dictionary, но через интерфейс.
    // Аллокация возвращается, потому что энумератор уезжает через IEnumerable.
    // Это тот же эффект, что у SortedList, только мы его создали сами.
    [Benchmark]
    public int Dictionary_AsIEnumerable_Foreach()
    {
        int sum = 0;

        IEnumerable<KeyValuePair<int, int>> pairs = _dictionary;
        foreach (KeyValuePair<int, int> pair in pairs)
        {
            sum += pair.Value;
        }

        return sum;
    }
}
