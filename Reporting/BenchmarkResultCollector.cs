using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace HiddenEnumerators.Reporting;

/// <summary>
/// Превращает результаты BenchmarkDotNet в плоский список строк,
/// с которым удобно работать дальше (сводка, графики).
/// </summary>
public static class BenchmarkResultCollector
{
    public static List<Row> Collect(Summary[] summaries)
    {
        List<Row> rows = [];
        foreach (Summary summary in summaries)
        {
            foreach (BenchmarkReport report in summary.Reports)
            {
                BenchmarkCase benchmarkCase = report.BenchmarkCase;

                double meanNs = report.ResultStatistics?.Mean ?? double.NaN;
                long allocated = report.GcStats.GetBytesAllocatedPerOperation(benchmarkCase) ?? 0;

                rows.Add(new Row(
                    benchmarkCase.Descriptor.Type.Name,
                    benchmarkCase.Descriptor.WorkloadMethod.Name,
                    benchmarkCase.Job.Environment.Runtime?.Name ?? benchmarkCase.Job.DisplayInfo,
                    benchmarkCase.Parameters.Count > 0 ? benchmarkCase.Parameters.PrintInfo : "",
                    meanNs,
                    allocated));
            }
        }

        return rows;
    }

    public static string GetResultsDirectory(Summary[] summaries) =>
        summaries.Length > 0
            ? summaries[0].ResultsDirectoryPath
            : Directory.GetCurrentDirectory();
}
