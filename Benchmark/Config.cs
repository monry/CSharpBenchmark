using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark
{
    internal class Config : ManualConfig
    {
        public Config()
        {
            WithOptions(ConfigOptions.DisableOptimizationsValidator);
            AddDiagnoser(MemoryDiagnoser.Default);
        }
    }
}