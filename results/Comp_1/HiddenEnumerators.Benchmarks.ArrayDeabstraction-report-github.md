```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.17763.3165/1809/October2018Update/Redstone5)
AMD Ryzen 9 5950X 3.39GHz, 1 CPU, 32 logical and 16 physical cores
.NET SDK 10.0.201
  [Host]    : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  .NET 8.0  : .NET 8.0.14 (8.0.14, 8.0.1425.11118), X64 RyuJIT x86-64-v3
  .NET 9.0  : .NET 9.0.15 (9.0.15, 9.0.1526.17522), X64 RyuJIT x86-64-v3


```
| Method                   | Job       | Runtime   | Mean        | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |------------:|----------:|----------:|------:|----------:|------------:|
| Array_Direct             | .NET 10.0 | .NET 10.0 | 124.8739 ns | 0.3609 ns | 0.3376 ns | 1.000 |         - |          NA |
| Array_AsIEnumerable      | .NET 10.0 | .NET 10.0 | 116.1846 ns | 0.3518 ns | 0.2938 ns | 0.930 |         - |          NA |
| Array_ViaHelper          | .NET 10.0 | .NET 10.0 | 115.3653 ns | 0.4493 ns | 0.4203 ns | 0.924 |         - |          NA |
| EmptyArray_AsIEnumerable | .NET 10.0 | .NET 10.0 |   0.0188 ns | 0.0024 ns | 0.0020 ns | 0.000 |         - |          NA |
| Array_Direct             | .NET 8.0  | .NET 8.0  | 117.0837 ns | 1.1270 ns | 0.9411 ns | 0.938 |         - |          NA |
| Array_AsIEnumerable      | .NET 8.0  | .NET 8.0  | 372.7327 ns | 0.4909 ns | 0.4352 ns | 2.985 |      32 B |          NA |
| Array_ViaHelper          | .NET 8.0  | .NET 8.0  | 404.1201 ns | 0.6210 ns | 0.5809 ns | 3.236 |      32 B |          NA |
| EmptyArray_AsIEnumerable | .NET 8.0  | .NET 8.0  |   2.3999 ns | 0.0684 ns | 0.0640 ns | 0.019 |         - |          NA |
| Array_Direct             | .NET 9.0  | .NET 9.0  | 124.3048 ns | 0.3072 ns | 0.2873 ns | 0.995 |         - |          NA |
| Array_AsIEnumerable      | .NET 9.0  | .NET 9.0  | 439.4316 ns | 0.3649 ns | 0.3235 ns | 3.519 |      32 B |          NA |
| Array_ViaHelper          | .NET 9.0  | .NET 9.0  | 439.2869 ns | 1.3589 ns | 1.2711 ns | 3.518 |      32 B |          NA |
| EmptyArray_AsIEnumerable | .NET 9.0  | .NET 9.0  |   2.1262 ns | 0.0091 ns | 0.0085 ns | 0.017 |         - |          NA |
