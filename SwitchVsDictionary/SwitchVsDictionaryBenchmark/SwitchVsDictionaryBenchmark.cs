using BenchmarkDotNet.Attributes;

namespace SwitchVsDictionaryBenchmark;

public class SwitchVsDictionaryBenchmark
{
   private const int Iterations = 1000;
    private readonly int[] _keys;

    public SwitchVsDictionaryBenchmark()
    {
        _keys = Enumerable.Range(0, Iterations).ToArray();
    }

    [Benchmark]
    public void TestSwitchCase10()
    {
        foreach (var key in _keys)
        {
            SwitchCase10.GetValue(key % 10 + 1);
        }
    }

    [Benchmark]
    public void TestSwitchCase100()
    {
        foreach (var key in _keys)
        {
            SwitchCase100.GetValue(key % 100 + 1);
        }
    }

    [Benchmark]
    public void TestSwitchCase500()
    {
        foreach (var key in _keys)
        {
            SwitchCase500.GetValue(key % 500 + 1);
        }
    }

    [Benchmark]
    public void TestDictionary10()
    {
        foreach (var key in _keys)
        {
            Dictionary10.GetValue(key % 10 + 1);
        }
    }

    [Benchmark]
    public void TestDictionary100()
    {
        foreach (var key in _keys)
        {
            Dictionary100.GetValue(key % 100 + 1);
        }
    }

    [Benchmark]
    public void TestDictionary500()
    {
        foreach (var key in _keys)
        {
            Dictionary500.GetValue(key % 500 + 1);
        }
    }
}