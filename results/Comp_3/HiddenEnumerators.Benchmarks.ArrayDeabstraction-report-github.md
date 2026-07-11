```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.20348.5256)
Intel Xeon Silver 4314 CPU 2.40GHz, 2 CPU, 64 logical and 32 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 8.0  : .NET 8.0.16 (8.0.16, 8.0.1625.21506), X64 RyuJIT x86-64-v4
  .NET 9.0  : .NET 9.0.5 (9.0.5, 9.0.525.21509), X64 RyuJIT x86-64-v4


```
| Method                   | Job       | Runtime   | Mean          | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |--------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| Array_Direct             | .NET 10.0 | .NET 10.0 |   247.1452 ns |  0.2258 ns |  0.1885 ns | 1.000 |    0.00 |         - |          NA |
| Array_AsIEnumerable      | .NET 10.0 | .NET 10.0 |   287.8710 ns |  0.1980 ns |  0.1546 ns | 1.165 |    0.00 |         - |          NA |
| Array_ViaHelper          | .NET 10.0 | .NET 10.0 |   289.7016 ns |  4.9966 ns |  4.6738 ns | 1.172 |    0.02 |         - |          NA |
| EmptyArray_AsIEnumerable | .NET 10.0 | .NET 10.0 |     0.0998 ns |  0.0348 ns |  0.0325 ns | 0.000 |    0.00 |         - |          NA |
| Array_Direct             | .NET 8.0  | .NET 8.0  |   275.7046 ns |  3.5154 ns |  3.2883 ns | 1.116 |    0.01 |         - |          NA |
| Array_AsIEnumerable      | .NET 8.0  | .NET 8.0  | 1,198.2760 ns |  3.2578 ns |  3.0473 ns | 4.848 |    0.01 |      32 B |          NA |
| Array_ViaHelper          | .NET 8.0  | .NET 8.0  | 1,234.0108 ns | 17.9413 ns | 16.7823 ns | 4.993 |    0.07 |      32 B |          NA |
| EmptyArray_AsIEnumerable | .NET 8.0  | .NET 8.0  |     4.2817 ns |  0.0092 ns |  0.0086 ns | 0.017 |    0.00 |         - |          NA |
| Array_Direct             | .NET 9.0  | .NET 9.0  |   252.6335 ns |  2.7491 ns |  2.5715 ns | 1.022 |    0.01 |         - |          NA |
| Array_AsIEnumerable      | .NET 9.0  | .NET 9.0  | 1,301.8179 ns |  3.0590 ns |  2.8614 ns | 5.267 |    0.01 |      32 B |          NA |
| Array_ViaHelper          | .NET 9.0  | .NET 9.0  | 1,346.1840 ns |  9.4194 ns |  8.8109 ns | 5.447 |    0.03 |      32 B |          NA |
| EmptyArray_AsIEnumerable | .NET 9.0  | .NET 9.0  |     4.1777 ns |  0.0361 ns |  0.0337 ns | 0.017 |    0.00 |         - |          NA |
