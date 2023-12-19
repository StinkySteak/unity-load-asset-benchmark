# Unity Load Asset API Benchmark
Comparing `Resources.Load` vs `Addressables.LoadAsset`. It's difficult to test using `Addressables.LoadAssetAsync` because it is ran on seperated thread. Don't take the results into account immediately, because this is premature optimization stuff. Especially the benchmark test is about 100,000 iterations and find the best API based on your game architecture instead!

## Setup

| Type             | Version                                                                  |
| ----------------- | ------------------------------------------------------------------ |
| Scripting Backend | IL2CPP |
| Unity Version | 2021.3.21f1 |
| Addressable Version | 1.19.19 |
| Platform | Windows 64-bit |

## Device

| Type             | Specs                                          |
| ----------------- | ------------------------------------------------------------------ |
| OS | IL2CPP |
| CPU | i7-11800H |
| RAM | 32GB |
| GPU | RTX 3050M |

## Benchmark
100,000 Iteration

| API             | Load Time                                                                |
| ----------------- | ------------------------------------------------------------------ |
| Resources | 91ms |
| Addressable | 406ms |

| API             | Second Load Time                                                                |
| ----------------- | ------------------------------------------------------------------ |
| Resources | 90ms |
| Addressable | 170ms |

