```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.20348.4893)
Intel Xeon Silver 4314 CPU 2.40GHz, 2 CPU, 64 logical and 32 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 8.0  : .NET 8.0.16 (8.0.16, 8.0.1625.21506), X64 RyuJIT x86-64-v4
  .NET 9.0  : .NET 9.0.5 (9.0.5, 9.0.525.21509), X64 RyuJIT x86-64-v4


```
| Method             | Job       | Runtime   | Size    | Mean            | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |---------- |---------- |-------- |----------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **10**      |        **11.02 ns** |      **0.114 ns** |      **0.101 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 10      |        12.78 ns |      0.281 ns |      0.263 ns |  1.16 |    0.03 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 10      |        12.56 ns |      0.140 ns |      0.124 ns |  1.14 |    0.01 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 10      |        12.17 ns |      0.283 ns |      0.367 ns |  1.10 |    0.03 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 10      |        45.06 ns |      0.865 ns |      0.767 ns |  4.09 |    0.08 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 10      |        42.90 ns |      0.873 ns |      1.073 ns |  3.89 |    0.10 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 10      |        11.06 ns |      0.106 ns |      0.099 ns |  1.00 |    0.01 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 10      |        38.93 ns |      0.672 ns |      0.629 ns |  3.53 |    0.06 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 10      |        37.83 ns |      0.446 ns |      0.417 ns |  3.43 |    0.05 |      40 B |          NA |
|                    |           |           |         |                 |               |               |       |         |           |             |
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **1000**    |       **722.89 ns** |      **7.903 ns** |      **7.393 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 1000    |       784.49 ns |     10.144 ns |      8.992 ns |  1.09 |    0.02 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 1000    |       740.27 ns |      7.999 ns |      7.091 ns |  1.02 |    0.01 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 1000    |       792.26 ns |     15.555 ns |     15.974 ns |  1.10 |    0.02 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 1000    |     2,413.19 ns |     13.549 ns |     12.011 ns |  3.34 |    0.04 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 1000    |     2,478.61 ns |     32.198 ns |     30.118 ns |  3.43 |    0.05 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 1000    |       727.97 ns |     10.478 ns |      9.801 ns |  1.01 |    0.02 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 1000    |     2,576.66 ns |     26.543 ns |     24.828 ns |  3.56 |    0.05 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 1000    |     2,793.28 ns |     54.028 ns |     53.063 ns |  3.86 |    0.08 |      40 B |          NA |
|                    |           |           |         |                 |               |               |       |         |           |             |
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **1000000** |   **796,092.62 ns** | **15,365.674 ns** | **18,870.430 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 1000000 |   748,952.03 ns | 10,792.551 ns | 10,095.359 ns |  0.94 |    0.02 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 1000000 |   744,069.76 ns |  8,512.831 ns |  7,962.908 ns |  0.94 |    0.02 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 1000000 |   805,072.38 ns | 16,080.088 ns | 18,517.853 ns |  1.01 |    0.03 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 1000000 | 2,600,299.67 ns | 30,431.050 ns | 26,976.333 ns |  3.27 |    0.08 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 1000000 | 2,571,829.24 ns | 49,823.188 ns | 59,310.966 ns |  3.23 |    0.10 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 1000000 |   736,431.76 ns |  6,763.765 ns |  6,326.830 ns |  0.93 |    0.02 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 1000000 | 2,687,700.42 ns | 39,973.986 ns | 33,380.089 ns |  3.38 |    0.09 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 1000000 | 2,625,569.28 ns | 19,193.360 ns | 17,014.414 ns |  3.30 |    0.08 |      40 B |          NA |
