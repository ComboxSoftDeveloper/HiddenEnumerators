```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.20348.4893)
Intel Xeon Silver 4314 CPU 2.40GHz, 2 CPU, 64 logical and 32 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 8.0  : .NET 8.0.16 (8.0.16, 8.0.1625.21506), X64 RyuJIT x86-64-v4
  .NET 9.0  : .NET 9.0.5 (9.0.5, 9.0.525.21509), X64 RyuJIT x86-64-v4


```
| Method                   | Job       | Runtime   | Mean          | Error      | StdDev     | Median        | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |--------------:|-----------:|-----------:|--------------:|------:|--------:|----------:|------------:|
| Array_Direct             | .NET 10.0 | .NET 10.0 |   268.5936 ns |  4.8678 ns |  4.5533 ns |   270.0612 ns | 1.000 |    0.02 |         - |          NA |
| Array_AsIEnumerable      | .NET 10.0 | .NET 10.0 |   299.5199 ns |  5.2549 ns |  4.9154 ns |   299.6065 ns | 1.115 |    0.03 |         - |          NA |
| Array_ViaHelper          | .NET 10.0 | .NET 10.0 |   291.0748 ns |  5.2416 ns |  4.9030 ns |   288.3949 ns | 1.084 |    0.03 |         - |          NA |
| EmptyArray_AsIEnumerable | .NET 10.0 | .NET 10.0 |     0.0075 ns |  0.0110 ns |  0.0098 ns |     0.0034 ns | 0.000 |    0.00 |         - |          NA |
| Array_Direct             | .NET 8.0  | .NET 8.0  |   289.4737 ns |  3.6081 ns |  3.0129 ns |   289.3401 ns | 1.078 |    0.02 |         - |          NA |
| Array_AsIEnumerable      | .NET 8.0  | .NET 8.0  | 1,252.6145 ns |  8.0925 ns |  7.5697 ns | 1,254.3228 ns | 4.665 |    0.08 |      32 B |          NA |
| Array_ViaHelper          | .NET 8.0  | .NET 8.0  | 1,246.3479 ns |  8.0846 ns |  7.5624 ns | 1,245.8334 ns | 4.642 |    0.08 |      32 B |          NA |
| EmptyArray_AsIEnumerable | .NET 8.0  | .NET 8.0  |     4.7954 ns |  0.1353 ns |  0.1390 ns |     4.8337 ns | 0.018 |    0.00 |         - |          NA |
| Array_Direct             | .NET 9.0  | .NET 9.0  |   287.2208 ns |  5.7189 ns |  6.1191 ns |   288.2076 ns | 1.070 |    0.03 |         - |          NA |
| Array_AsIEnumerable      | .NET 9.0  | .NET 9.0  | 1,324.5585 ns | 14.5774 ns | 13.6357 ns | 1,324.1402 ns | 4.933 |    0.09 |      32 B |          NA |
| Array_ViaHelper          | .NET 9.0  | .NET 9.0  | 1,448.2525 ns | 28.8673 ns | 55.6176 ns | 1,443.0607 ns | 5.393 |    0.22 |      32 B |          NA |
| EmptyArray_AsIEnumerable | .NET 9.0  | .NET 9.0  |     4.2699 ns |  0.0586 ns |  0.0548 ns |     4.2671 ns | 0.016 |    0.00 |         - |          NA |
