using System.Text;

namespace HiddenEnumerators.Reporting;

/// <summary>
/// Короткая текстовая сводка по всем классам: Method / Params / Runtime / Mean / Allocated.
/// Печатается в консоль в самом конце и сохраняется в _RECAP.txt.
/// </summary>
public static class RecapReport
{
    public static string Build(List<Row> rows)
    {
        StringBuilder recap = new();
        recap.AppendLine("==================== СВОДКА ====================");

        foreach (IGrouping<string, Row> classGroup in rows.GroupBy(x => x.ClassName))
        {
            recap.AppendLine();
            recap.AppendLine($"--- {classGroup.Key} ---");
            recap.AppendLine($"{"Method",-34} {"Params",-14} {"Runtime",-10} {"Mean",16} {"Allocated",10}");

            IOrderedEnumerable<Row> ordered = classGroup
                .OrderBy(x => x.Parameters)
                .ThenBy(x => x.Method)
                .ThenBy(x => x.Runtime);

            foreach (Row row in ordered)
            {
                recap.AppendLine($"{row.Method,-34} {row.Parameters,-14} {row.Runtime,-10} {FormatTime(row.MeanNs),16} {FormatAlloc(row.AllocatedBytes),10}");
            }
        }

        recap.AppendLine();
        recap.AppendLine("================================================");

        return recap.ToString();
    }

    public static string WriteAndPrint(List<Row> rows, string resultsDir)
    {
        string recap = Build(rows);

        Console.WriteLine();
        Console.WriteLine(recap);

        string recapPath = Path.Combine(resultsDir, "_RECAP.txt");
        File.WriteAllText(recapPath, recap, Encoding.UTF8);

        return recapPath;
    }

    private static string FormatTime(double ns) =>
        ns switch
        {
            double.NaN => "n/a",
            < 1_000 => $"{ns:F3} ns",
            < 1_000_000 => $"{ns / 1_000:F3} us",
            _ => $"{ns / 1_000_000:F3} ms"
        };

    private static string FormatAlloc(long bytes) => bytes == 0 ? "-" : $"{bytes} B";
}
