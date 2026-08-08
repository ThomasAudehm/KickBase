using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using KickBase.Analyzers.Codefixes;
using KickBase.Domain;
using Microsoft.CodeAnalysis; 

namespace KickBase.Analyzers.Tests;

public class PropertyMeaningTests
{
    [Fact]
    public async Task Check_For_Missing_Attributes_Async()
    {
        const string beforeAnalyzer = """
                                      using KickBase.Domain;
                                      namespace Test;
                                      [KickBaseApi]
                                      public class MyClass
                                      {
                                        public string [|MyProperty|] { get; set; }
                                      }
                                      """;

        const string fixedCode = """
                                 using KickBase.Domain;
                                 namespace Test;
                                 [KickBaseApi]
                                 public class MyClass
                                 {
                                     [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
                                     public string MyProperty { get; set; }
                                 }
                                 """;
        
        var test = new CSharpCodeFixTest<KickBasePropertyMeaningAnalyzer, KickBasePropertyMeaningCodeFixProvider, DefaultVerifier>
        {
            TestCode = beforeAnalyzer,
            FixedCode = fixedCode,
            ReferenceAssemblies = ReferenceAssemblies.Net.Net100
        };

        test.SolutionTransforms.Add((solution, projectId) =>
        {
            //Get the Attributes from the Assembly and Override the ProjectId 
            var assemblyLocation = typeof(KickBaseApi).Assembly.Location;
            var project = solution.GetProject(projectId);
            project = project!.AddMetadataReference(MetadataReference.CreateFromFile(assemblyLocation));
            
            return project.Solution;
        });
        
        await test.RunAsync();
    }
}