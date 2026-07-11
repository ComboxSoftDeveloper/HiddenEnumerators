```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.20348.4893)
Intel Xeon Silver 4314 CPU 2.40GHz, 2 CPU, 64 logical and 32 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 8.0  : .NET 8.0.16 (8.0.16, 8.0.1625.21506), X64 RyuJIT x86-64-v4
  .NET 9.0  : .NET 9.0.5 (9.0.5, 9.0.525.21509), X64 RyuJIT x86-64-v4


```
| Method                           | Job       | Runtime   | Mean      | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------- |---------- |---------- |----------:|---------:|---------:|------:|--------:|----------:|------------:|
| Dictionary_Foreach               | .NET 10.0 | .NET 10.0 |  16.02 ns | 0.165 ns | 0.155 ns |  1.00 |    0.01 |         - |          NA |
| SortedList_Foreach               | .NET 10.0 | .NET 10.0 |  22.25 ns | 0.484 ns | 0.475 ns |  1.39 |    0.03 |         - |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 10.0 | .NET 10.0 |  24.19 ns | 0.523 ns | 0.916 ns |  1.51 |    0.06 |         - |          NA |
| Dictionary_Foreach               | .NET 8.0  | .NET 8.0  |  18.82 ns | 0.403 ns | 0.414 ns |  1.17 |    0.03 |         - |          NA |
| SortedList_Foreach               | .NET 8.0  | .NET 8.0  |  65.92 ns | 1.342 ns | 1.255 ns |  4.11 |    0.09 |      48 B |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 8.0  | .NET 8.0  |  59.79 ns | 0.823 ns | 0.769 ns |  3.73 |    0.06 |      48 B |          NA |
| Dictionary_Foreach               | .NET 9.0  | .NET 9.0  |  18.01 ns | 0.394 ns | 0.454 ns |  1.12 |    0.03 |         - |          NA |
| SortedList_Foreach               | .NET 9.0  | .NET 9.0  |  68.66 ns | 1.327 ns | 1.904 ns |  4.29 |    0.12 |      48 B |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 9.0  | .NET 9.0  | 148.67 ns | 1.593 ns | 1.490 ns |  9.28 |    0.12 |      48 B |          NA |
