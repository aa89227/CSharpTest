using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace SwitchVsDictionaryBenchmark.Generator;

[Generator]
public class SwitchDictionaryGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context) { }

    public void Execute(GeneratorExecutionContext context)
    {
        GenerateSwitchCases(context, 10);
        GenerateSwitchCases(context, 100);
        GenerateSwitchCases(context, 500);
    }

    private void GenerateSwitchCases(GeneratorExecutionContext context, int count)
    {
        var className = $"SwitchCase{count}";
        var source = new StringBuilder($$"""

                                         using System.Collections.Generic;

                                         public static class {{className}}
                                         {
                                             public static int GetValue(int key)
                                             {
                                                 switch (key)
                                                 {
                                         """);

        for (int i = 1; i <= count; i++)
        {
            source.AppendLine($"""
                               
                                           case {i}:
                                               return {i};
                               """);
        }

        source.AppendLine("""
                          
                                      default:
                                          throw new KeyNotFoundException();
                                  }
                              }
                          }
                          """);

        context.AddSource($"{className}.g.cs", SourceText.From(source.ToString(), Encoding.UTF8));

        // Generate Dictionary class
        className = $"Dictionary{count}";
        source = new StringBuilder($$"""

                                     using System.Collections.Generic;

                                     public static class {{className}}
                                     {
                                         private static readonly Dictionary<int, int> _map = new()
                                         {
                                     """);

        for (int i = 1; i <= count; i++)
        {
            source.AppendLine($"""
                                       [{i}] = {i},
                               """);
        }

        source.AppendLine("""
                              };
                          
                              public static int GetValue(int key)
                              {
                                  if (_map.TryGetValue(key, out var value))
                                  {
                                      return value;
                                  }
                                  throw new KeyNotFoundException();
                              }
                          }
                          """);

        context.AddSource($"{className}.g.cs", SourceText.From(source.ToString(), Encoding.UTF8));
    }
}