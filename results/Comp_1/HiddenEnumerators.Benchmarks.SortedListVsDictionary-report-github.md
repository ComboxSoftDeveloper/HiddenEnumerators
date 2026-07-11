```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.17763.3165/1809/October2018Update/Redstone5)
AMD Ryzen 9 5950X 3.39GHz, 1 CPU, 32 logical and 16 physical cores
.NET SDK 10.0.201
  [Host]    : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  .NET 8.0  : .NET 8.0.14 (8.0.14, 8.0.1425.11118), X64 RyuJIT x86-64-v3
  .NET 9.0  : .NET 9.0.15 (9.0.15, 9.0.1526.17522), X64 RyuJIT x86-64-v3


```
| Method                           | Job       | Runtime   | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------- |---------- |---------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
| Dictionary_Foreach               | .NET 10.0 | .NET 10.0 | 10.118 ns | 0.1211 ns | 0.1133 ns | 10.088 ns |  1.00 |    0.02 |         - |          NA |
| SortedList_Foreach               | .NET 10.0 | .NET 10.0 | 10.234 ns | 0.1749 ns | 0.1636 ns | 10.183 ns |  1.01 |    0.02 |         - |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 10.0 | .NET 10.0 | 11.667 ns | 0.2474 ns | 0.4460 ns | 11.467 ns |  1.15 |    0.05 |         - |          NA |
| Dictionary_Foreach               | .NET 8.0  | .NET 8.0  | 13.131 ns | 0.0262 ns | 0.0232 ns | 13.128 ns |  1.30 |    0.01 |         - |          NA |
| SortedList_Foreach               | .NET 8.0  | .NET 8.0  | 38.891 ns | 0.8997 ns | 2.6527 ns | 40.699 ns |  3.84 |    0.26 |      48 B |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 8.0  | .NET 8.0  | 35.177 ns | 0.7421 ns | 2.1764 ns | 36.559 ns |  3.48 |    0.22 |      48 B |          NA |
| Dictionary_Foreach               | .NET 9.0  | .NET 9.0  |  9.597 ns | 0.1141 ns | 0.0891 ns |  9.564 ns |  0.95 |    0.01 |         - |          NA |
| SortedList_Foreach               | .NET 9.0  | .NET 9.0  | 33.182 ns | 0.0783 ns | 0.0733 ns | 33.178 ns |  3.28 |    0.04 |      48 B |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 9.0  | .NET 9.0  | 91.100 ns | 0.1589 ns | 0.1487 ns | 91.124 ns |  9.01 |    0.10 |      48 B |          NA |
