```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.17763.3165/1809/October2018Update/Redstone5)
AMD Ryzen 9 5950X 3.39GHz, 1 CPU, 32 logical and 16 physical cores
.NET SDK 10.0.201
  [Host]    : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  .NET 8.0  : .NET 8.0.14 (8.0.14, 8.0.1425.11118), X64 RyuJIT x86-64-v3
  .NET 9.0  : .NET 9.0.15 (9.0.15, 9.0.1526.17522), X64 RyuJIT x86-64-v3


```
| Method             | Job       | Runtime   | Size    | Mean             | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |---------- |---------- |-------- |-----------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **10**      |         **5.251 ns** |     **0.0293 ns** |     **0.0274 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 10      |         6.270 ns |     0.0427 ns |     0.0378 ns |  1.19 |    0.01 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 10      |         6.449 ns |     0.1110 ns |     0.1885 ns |  1.23 |    0.04 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 10      |         5.412 ns |     0.0192 ns |     0.0180 ns |  1.03 |    0.01 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 10      |        18.338 ns |     0.0327 ns |     0.0306 ns |  3.49 |    0.02 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 10      |        18.803 ns |     0.0679 ns |     0.0635 ns |  3.58 |    0.02 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 10      |         5.428 ns |     0.0421 ns |     0.0394 ns |  1.03 |    0.01 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 10      |        18.102 ns |     0.0393 ns |     0.0368 ns |  3.45 |    0.02 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 10      |        18.232 ns |     0.0463 ns |     0.0433 ns |  3.47 |    0.02 |      40 B |          NA |
|                    |           |           |         |                  |               |               |       |         |           |             |
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **1000**    |       **450.469 ns** |     **0.1634 ns** |     **0.1529 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 1000    |       455.939 ns |     1.3095 ns |     1.0935 ns |  1.01 |    0.00 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 1000    |       456.084 ns |     3.4082 ns |     3.0213 ns |  1.01 |    0.01 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 1000    |       454.670 ns |     0.5054 ns |     0.4727 ns |  1.01 |    0.00 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 1000    |     1,124.052 ns |     1.8815 ns |     1.7599 ns |  2.50 |    0.00 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 1000    |     1,158.014 ns |     1.8592 ns |     1.7391 ns |  2.57 |    0.00 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 1000    |       451.935 ns |     0.2179 ns |     0.2038 ns |  1.00 |    0.00 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 1000    |     1,243.911 ns |     0.4985 ns |     0.4419 ns |  2.76 |    0.00 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 1000    |     1,257.544 ns |     0.6929 ns |     0.6142 ns |  2.79 |    0.00 |      40 B |          NA |
|                    |           |           |         |                  |               |               |       |         |           |             |
| **List_Direct**        | **.NET 10.0** | **.NET 10.0** | **1000000** |   **448,934.395 ns** |   **165.7827 ns** |   **155.0732 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| List_AsIEnumerable | .NET 10.0 | .NET 10.0 | 1000000 |   450,581.061 ns |   204.8914 ns |   191.6556 ns |  1.00 |    0.00 |         - |          NA |
| List_ViaHelper     | .NET 10.0 | .NET 10.0 | 1000000 |   453,765.161 ns |   315.5040 ns |   279.6861 ns |  1.01 |    0.00 |         - |          NA |
| List_Direct        | .NET 8.0  | .NET 8.0  | 1000000 |   455,142.338 ns | 1,926.3776 ns | 1,608.6126 ns |  1.01 |    0.00 |         - |          NA |
| List_AsIEnumerable | .NET 8.0  | .NET 8.0  | 1000000 | 1,100,473.396 ns | 1,231.0626 ns | 1,091.3049 ns |  2.45 |    0.00 |      40 B |          NA |
| List_ViaHelper     | .NET 8.0  | .NET 8.0  | 1000000 | 1,145,045.671 ns |   948.8354 ns |   887.5412 ns |  2.55 |    0.00 |      40 B |          NA |
| List_Direct        | .NET 9.0  | .NET 9.0  | 1000000 |   449,297.731 ns |   169.4010 ns |   158.4578 ns |  1.00 |    0.00 |         - |          NA |
| List_AsIEnumerable | .NET 9.0  | .NET 9.0  | 1000000 | 1,243,873.965 ns | 1,127.8022 ns | 1,054.9469 ns |  2.77 |    0.00 |      40 B |          NA |
| List_ViaHelper     | .NET 9.0  | .NET 9.0  | 1000000 | 1,244,423.717 ns |   993.9661 ns |   881.1250 ns |  2.77 |    0.00 |      40 B |          NA |
