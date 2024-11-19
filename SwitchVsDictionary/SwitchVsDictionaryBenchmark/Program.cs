using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

var config = DefaultConfig.Instance
    .HideColumns([Column.EnvironmentVariables])
    .AddJob(Job.Default.WithRuntime(CoreRuntime.Core80).WithId(".NET 8"))
    .AddJob(Job.Default.WithRuntime(CoreRuntime.Core90).WithId(".NET 9"));
BenchmarkRunner.Run<SwitchVsDictionaryBenchmark.SwitchVsDictionaryBenchmark>(config);