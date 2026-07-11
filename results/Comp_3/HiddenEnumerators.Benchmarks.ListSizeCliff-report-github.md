```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.20348.5256)
Intel Xeon Silver 4314 CPU 2.40GHz, 2 CPU, 64 logical and 32 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 8.0  : .NET 8.0.16 (8.0.16, 8.0.1625.21506), X64 RyuJIT x86-64-v4
  .NET 9.0  : .NET 9.0.5 (9.0.5, 9.0.525.21509), X64 RyuJIT x86-64-v4


```
| Method             | Job       | Runtime   | Size    | Mean            | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |---------- |---------- |-------- |----------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **10**      |        **10.86 ns** |      **0.125 ns** |      **0.117 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 10      |        11.78 ns |      0.188 ns |      0.176 ns |  1.08 |    0.02 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 10      |        12.65 ns |      0.178 ns |      0.158 ns |  1.16 |    0.02 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 10      |        11.21 ns |      0.159 ns |      0.149 ns |  1.03 |    0.02 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 10      |        41.12 ns |      0.540 ns |      0.505 ns |  3.79 |    0.06 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 10      |        38.26 ns |      0.124 ns |      0.110 ns |  3.52 |    0.04 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 10      |        10.75 ns |      0.005 ns |      0.005 ns |  0.99 |    0.01 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 10      |        34.92 ns |      0.217 ns |      0.203 ns |  3.22 |    0.04 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 10      |        35.45 ns |      0.207 ns |      0.193 ns |  3.26 |    0.04 |      40 B |          NA |
|                    |           |           |         |                 |               |               |       |         |           |             |
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **1000**    |       **731.48 ns** |     **12.774 ns** |     **11.949 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 1000    |       717.67 ns |      1.122 ns |      0.937 ns |  0.98 |    0.02 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 1000    |       719.68 ns |      1.142 ns |      0.954 ns |  0.98 |    0.02 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 1000    |       723.82 ns |      2.543 ns |      2.379 ns |  0.99 |    0.02 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 1000    |     2,377.87 ns |     12.890 ns |     12.057 ns |  3.25 |    0.05 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 1000    |     2,488.96 ns |     15.890 ns |     14.086 ns |  3.40 |    0.06 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 1000    |       721.62 ns |      6.738 ns |      6.303 ns |  0.99 |    0.02 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 1000    |     2,611.20 ns |     33.223 ns |     31.077 ns |  3.57 |    0.07 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 1000    |     2,552.13 ns |      2.386 ns |      1.992 ns |  3.49 |    0.06 |      40 B |          NA |
|                    |           |           |         |                 |               |               |       |         |           |             |
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **1000000** |   **721,327.28 ns** |  **1,293.703 ns** |  **1,080.301 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 1000000 |   749,167.92 ns |  9,211.273 ns |  8,165.554 ns |  1.04 |    0.01 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 1000000 |   723,362.38 ns |    912.447 ns |    761.934 ns |  1.00 |    0.00 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 1000000 |   723,711.82 ns |  2,776.326 ns |  2,461.141 ns |  1.00 |    0.00 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 1000000 | 2,536,939.44 ns | 39,902.998 ns | 37,325.289 ns |  3.52 |    0.05 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 1000000 | 2,365,296.65 ns |  6,158.954 ns |  5,761.089 ns |  3.28 |    0.01 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 1000000 |   751,706.08 ns | 14,478.703 ns | 19,328.655 ns |  1.04 |    0.03 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 1000000 | 2,563,917.53 ns |  6,716.936 ns |  6,283.027 ns |  3.55 |    0.01 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 1000000 | 2,562,055.53 ns |  6,971.204 ns |  5,821.271 ns |  3.55 |    0.01 |      40 B |          NA |
