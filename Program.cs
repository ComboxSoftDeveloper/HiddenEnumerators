using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using HiddenEnumerators.Benchmarks;
using HiddenEnumerators.Reporting;

ManualConfig config = ManualConfig.Create(DefaultConfig.Instance)
    .AddExporter(MarkdownExporter.GitHub)
    .AddExporter(HtmlExporter.Default)
    .AddExporter(CsvExporter.Default);

Summary[] summaries = BenchmarkRunner.Run([
    typeof(SortedListVsDictionary),
    typeof(ArrayDeabstraction),
    typeof(ListSizeCliff)
], config);

// dotnet run -c Release -f net10.0

List<Row> rows = BenchmarkResultCollector.Collect(summaries);
string resultsDir = BenchmarkResultCollector.GetResultsDirectory(summaries);

string recapPath = RecapReport.WriteAndPrint(rows, resultsDir);
string chartsPath = ChartsReport.Write(rows, resultsDir);

Console.WriteLine($"Сводка:   {recapPath}");
Console.WriteLine($"Графики:  {chartsPath}");
Console.WriteLine($"Таблицы:  {resultsDir} (*-report-github.md - готовые для статьи)");
