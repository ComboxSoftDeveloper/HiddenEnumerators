```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
Intel Core i9-10900KF CPU 3.70GHz, 1 CPU, 20 logical and 10 physical cores
.NET SDK 10.0.301
  [Host]    : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v3
  .NET 8.0  : .NET 8.0.28 (8.0.28, 8.0.2826.26413), X64 RyuJIT x86-64-v3
  .NET 9.0  : .NET 9.0.17 (9.0.17, 9.0.1726.26416), X64 RyuJIT x86-64-v3


```
| Method                           | Job       | Runtime   | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------- |---------- |---------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| Dictionary_Foreach               | .NET 10.0 | .NET 10.0 | 10.16 ns | 0.042 ns | 0.039 ns |  1.00 |    0.01 |         - |          NA |
| SortedList_Foreach               | .NET 10.0 | .NET 10.0 | 12.18 ns | 0.077 ns | 0.072 ns |  1.20 |    0.01 |         - |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 10.0 | .NET 10.0 | 12.53 ns | 0.138 ns | 0.130 ns |  1.23 |    0.01 |         - |          NA |
| Dictionary_Foreach               | .NET 8.0  | .NET 8.0  | 11.71 ns | 0.104 ns | 0.097 ns |  1.15 |    0.01 |         - |          NA |
| SortedList_Foreach               | .NET 8.0  | .NET 8.0  | 37.14 ns | 0.457 ns | 0.428 ns |  3.66 |    0.04 |      48 B |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 8.0  | .NET 8.0  | 35.10 ns | 0.317 ns | 0.297 ns |  3.46 |    0.03 |      48 B |          NA |
| Dictionary_Foreach               | .NET 9.0  | .NET 9.0  | 10.33 ns | 0.064 ns | 0.060 ns |  1.02 |    0.01 |         - |          NA |
| SortedList_Foreach               | .NET 9.0  | .NET 9.0  | 37.74 ns | 0.626 ns | 0.555 ns |  3.72 |    0.05 |      48 B |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 9.0  | .NET 9.0  | 84.98 ns | 0.832 ns | 0.778 ns |  8.37 |    0.08 |      48 B |          NA |
