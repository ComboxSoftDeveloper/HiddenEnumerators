using System.Text;
using System.Text.Json;

namespace HiddenEnumerators.Reporting;

/// <summary>
/// Страница с графиками (Chart.js с CDN, без nuget-пакетов): на каждую группу
/// класс+параметры два столбчатых графика - время и аллокации, серии по рантаймам.
/// Сохраняется в _CHARTS.html. Для отрисовки странице нужен интернет.
/// </summary>
public static class ChartsReport
{
    public static string Write(List<Row> rows, string resultsDir)
    {
        string chartsPath = Path.Combine(resultsDir, "_CHARTS.html");
        File.WriteAllText(chartsPath, Build(rows), Encoding.UTF8);

        return chartsPath;
    }

    private static string Build(List<Row> rows)
    {
        var groups = rows
            .GroupBy(x => (x.ClassName, x.Parameters))
            .Select(grouping =>
            {
                string[] methods = grouping
                    .Select(x => x.Method)
                    .Distinct()
                    .ToArray();

                string[] runtimes = grouping
                    .Select(x => x.Runtime)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToArray();

                var series = runtimes.Select(runtime => new
                {
                    name = runtime,

                    mean = methods
                        .Select(m => grouping.FirstOrDefault(x => x.Method == m && x.Runtime == runtime)?.MeanNs ?? 0)
                        .ToArray(),

                    alloc = methods
                        .Select(m => grouping.FirstOrDefault(x => x.Method == m && x.Runtime == runtime)?.AllocatedBytes ?? 0)
                        .ToArray()
                }).ToArray();

                string title = string.IsNullOrEmpty(grouping.Key.Parameters)
                    ? grouping.Key.ClassName
                    : $"{grouping.Key.ClassName} ({grouping.Key.Parameters})";

                return new
                {
                    title,
                    labels = methods,
                    series
                };
            })
            .ToArray();

        string json = JsonSerializer.Serialize(groups);

        return """
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>HiddenEnumerators - результаты</title>
<script src="https://cdn.jsdelivr.net/npm/chart.js@4"></script>
<style>
  body { font-family: 'Segoe UI', Arial, sans-serif; max-width: 1000px; margin: 24px auto; }
  h2 { margin: 32px 0 4px 0; }
  .hint { color: #666; margin: 0 0 8px 0; }
  canvas { margin: 8px 0 24px 0; }
</style>
</head>
<body>
<h1>Скрытые аллокации foreach: .NET 8 vs 9 vs 10</h1>
<p class="hint">Странице нужен интернет для загрузки Chart.js - открывайте на машине с доступом в сеть.</p>
<div id="root"></div>
<script>
const DATA = __JSON__;
const COLORS = { '.NET 8.0': '#8e8e93', '.NET 9.0': '#f0a30a', '.NET 10.0': '#512bd4' };
const root = document.getElementById('root');

function addChart(title, labels, datasets, yTitle) {
  const h = document.createElement('h2');
  h.textContent = title;
  root.appendChild(h);
  const canvas = document.createElement('canvas');
  canvas.height = 90;
  root.appendChild(canvas);
  new Chart(canvas, {
    type: 'bar',
    data: { labels, datasets },
    options: {
      responsive: true,
      plugins: { legend: { position: 'top' } },
      scales: { y: { beginAtZero: true, title: { display: true, text: yTitle } } }
    }
  });
}

for (const g of DATA) {
  addChart(
    g.title + ' - время',
    g.labels,
    g.series.map(s => ({ label: s.name, data: s.mean, backgroundColor: COLORS[s.name] ?? '#444' })),
    'ns/op (меньше - лучше)');

  addChart(
    g.title + ' - аллокации',
    g.labels,
    g.series.map(s => ({ label: s.name, data: s.alloc, backgroundColor: COLORS[s.name] ?? '#444' })),
    'B/op (ноль - идеал)');
}
</script>
</body>
</html>
""".Replace("__JSON__", json);
    }
}
