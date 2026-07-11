```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
Intel Core i9-10900KF CPU 3.70GHz, 1 CPU, 20 logical and 10 physical cores
.NET SDK 10.0.301
  [Host]    : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v3
  .NET 8.0  : .NET 8.0.28 (8.0.28, 8.0.2826.26413), X64 RyuJIT x86-64-v3
  .NET 9.0  : .NET 9.0.17 (9.0.17, 9.0.1726.26416), X64 RyuJIT x86-64-v3


```
| Method                   | Job       | Runtime   | Mean        | Error     | StdDev    | Median      | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |------------:|----------:|----------:|------------:|------:|--------:|----------:|------------:|
| Array_Direct             | .NET 10.0 | .NET 10.0 | 131.1743 ns | 0.0261 ns | 0.0218 ns | 131.1703 ns | 1.000 |    0.00 |         - |          NA |
| Array_AsIEnumerable      | .NET 10.0 | .NET 10.0 | 152.9469 ns | 1.2626 ns | 1.1811 ns | 152.6379 ns | 1.166 |    0.01 |         - |          NA |
| Array_ViaHelper          | .NET 10.0 | .NET 10.0 | 150.8422 ns | 0.9712 ns | 0.9084 ns | 150.8427 ns | 1.150 |    0.01 |         - |          NA |
| EmptyArray_AsIEnumerable | .NET 10.0 | .NET 10.0 |   0.0003 ns | 0.0006 ns | 0.0006 ns |   0.0000 ns | 0.000 |    0.00 |         - |          NA |
| Array_Direct             | .NET 8.0  | .NET 8.0  | 139.8498 ns | 1.3068 ns | 1.2224 ns | 139.9193 ns | 1.066 |    0.01 |         - |          NA |
| Array_AsIEnumerable      | .NET 8.0  | .NET 8.0  | 582.4156 ns | 2.8783 ns | 2.5515 ns | 583.0177 ns | 4.440 |    0.02 |      32 B |          NA |
| Array_ViaHelper          | .NET 8.0  | .NET 8.0  | 580.1560 ns | 2.6693 ns | 2.4968 ns | 580.8382 ns | 4.423 |    0.02 |      32 B |          NA |
| EmptyArray_AsIEnumerable | .NET 8.0  | .NET 8.0  |   2.7780 ns | 0.1009 ns | 0.2976 ns |   2.5979 ns | 0.021 |    0.00 |         - |          NA |
| Array_Direct             | .NET 9.0  | .NET 9.0  | 128.8994 ns | 0.7886 ns | 0.7376 ns | 129.0318 ns | 0.983 |    0.01 |         - |          NA |
| Array_AsIEnumerable      | .NET 9.0  | .NET 9.0  | 682.5440 ns | 4.4134 ns | 4.1283 ns | 684.7931 ns | 5.203 |    0.03 |      32 B |          NA |
| Array_ViaHelper          | .NET 9.0  | .NET 9.0  | 679.2527 ns | 4.0546 ns | 3.7927 ns | 679.3131 ns | 5.178 |    0.03 |      32 B |          NA |
| EmptyArray_AsIEnumerable | .NET 9.0  | .NET 9.0  |   2.2612 ns | 0.0220 ns | 0.0206 ns |   2.2715 ns | 0.017 |    0.00 |         - |          NA |
