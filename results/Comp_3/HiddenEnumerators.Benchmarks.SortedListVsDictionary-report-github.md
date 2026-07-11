```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.20348.5256)
Intel Xeon Silver 4314 CPU 2.40GHz, 2 CPU, 64 logical and 32 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 8.0  : .NET 8.0.16 (8.0.16, 8.0.1625.21506), X64 RyuJIT x86-64-v4
  .NET 9.0  : .NET 9.0.5 (9.0.5, 9.0.525.21509), X64 RyuJIT x86-64-v4


```
| Method                           | Job       | Runtime   | Mean      | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------- |---------- |---------- |----------:|---------:|---------:|------:|--------:|----------:|------------:|
| Dictionary_Foreach               | .NET 10.0 | .NET 10.0 |  15.66 ns | 0.075 ns | 0.067 ns |  1.00 |    0.01 |         - |          NA |
| SortedList_Foreach               | .NET 10.0 | .NET 10.0 |  20.90 ns | 0.246 ns | 0.218 ns |  1.33 |    0.01 |         - |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 10.0 | .NET 10.0 |  21.73 ns | 0.201 ns | 0.188 ns |  1.39 |    0.01 |         - |          NA |
| Dictionary_Foreach               | .NET 8.0  | .NET 8.0  |  16.85 ns | 0.192 ns | 0.180 ns |  1.08 |    0.01 |         - |          NA |
| SortedList_Foreach               | .NET 8.0  | .NET 8.0  |  62.20 ns | 0.349 ns | 0.327 ns |  3.97 |    0.03 |      48 B |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 8.0  | .NET 8.0  |  61.25 ns | 0.336 ns | 0.262 ns |  3.91 |    0.02 |      48 B |          NA |
| Dictionary_Foreach               | .NET 9.0  | .NET 9.0  |  16.98 ns | 0.115 ns | 0.107 ns |  1.08 |    0.01 |         - |          NA |
| SortedList_Foreach               | .NET 9.0  | .NET 9.0  |  61.51 ns | 0.398 ns | 0.332 ns |  3.93 |    0.03 |      48 B |          NA |
| Dictionary_AsIEnumerable_Foreach | .NET 9.0  | .NET 9.0  | 144.57 ns | 0.357 ns | 0.316 ns |  9.23 |    0.04 |      48 B |          NA |
