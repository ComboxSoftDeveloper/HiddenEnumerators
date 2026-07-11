```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
Intel Core i9-10900KF CPU 3.70GHz, 1 CPU, 20 logical and 10 physical cores
.NET SDK 10.0.301
  [Host]    : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v3
  .NET 8.0  : .NET 8.0.28 (8.0.28, 8.0.2826.26413), X64 RyuJIT x86-64-v3
  .NET 9.0  : .NET 9.0.17 (9.0.17, 9.0.1726.26416), X64 RyuJIT x86-64-v3


```
| Method             | Job       | Runtime   | Size    | Mean             | Error          | StdDev         | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |---------- |---------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|----------:|------------:|
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **10**      |         **5.638 ns** |      **0.0180 ns** |      **0.0160 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 10      |         7.935 ns |      0.0411 ns |      0.0385 ns |  1.41 |    0.01 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 10      |         7.963 ns |      0.0835 ns |      0.0781 ns |  1.41 |    0.01 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 10      |         5.651 ns |      0.0202 ns |      0.0189 ns |  1.00 |    0.00 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 10      |        21.335 ns |      0.2968 ns |      0.2776 ns |  3.78 |    0.05 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 10      |        21.681 ns |      0.2741 ns |      0.2564 ns |  3.85 |    0.05 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 10      |         5.679 ns |      0.0521 ns |      0.0487 ns |  1.01 |    0.01 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 10      |        20.835 ns |      0.4125 ns |      0.3859 ns |  3.70 |    0.07 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 10      |        20.754 ns |      0.1462 ns |      0.1368 ns |  3.68 |    0.03 |      40 B |          NA |
|                    |           |           |         |                  |                |                |       |         |           |             |
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **1000**    |       **407.838 ns** |      **1.3362 ns** |      **1.2499 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 1000    |       417.770 ns |      3.6373 ns |      3.4023 ns |  1.02 |    0.01 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 1000    |       418.381 ns |      2.3896 ns |      2.2352 ns |  1.03 |    0.01 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 1000    |       540.332 ns |      2.3091 ns |      2.1599 ns |  1.32 |    0.01 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 1000    |     1,354.263 ns |      9.9316 ns |      9.2901 ns |  3.32 |    0.02 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 1000    |     1,347.821 ns |      3.7952 ns |      3.3644 ns |  3.30 |    0.01 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 1000    |       406.826 ns |      1.3335 ns |      1.1821 ns |  1.00 |    0.00 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 1000    |     1,362.683 ns |      5.6985 ns |      5.3303 ns |  3.34 |    0.02 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 1000    |     1,361.274 ns |      9.1166 ns |      8.0816 ns |  3.34 |    0.02 |      40 B |          NA |
|                    |           |           |         |                  |                |                |       |         |           |             |
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **1000000** |   **416,097.380 ns** |  **2,218.2597 ns** |  **2,074.9615 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 1000000 |   419,686.637 ns |  2,473.3705 ns |  2,313.5923 ns |  1.01 |    0.01 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 1000000 |   417,819.775 ns |  1,646.2570 ns |  1,459.3639 ns |  1.00 |    0.01 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 1000000 |   471,606.281 ns |  1,260.8601 ns |  1,117.7197 ns |  1.13 |    0.01 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 1000000 | 1,334,484.029 ns |  5,396.6948 ns |  4,506.4845 ns |  3.21 |    0.02 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 1000000 | 1,340,837.709 ns |  6,583.3724 ns |  5,835.9882 ns |  3.22 |    0.02 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 1000000 |   415,001.416 ns |  1,629.4106 ns |  1,444.4301 ns |  1.00 |    0.01 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 1000000 | 1,389,870.833 ns | 25,992.1594 ns | 27,811.3194 ns |  3.34 |    0.07 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 1000000 | 1,364,448.919 ns |  2,726.6581 ns |  2,550.5176 ns |  3.28 |    0.02 |      40 B |          NA |
