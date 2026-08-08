using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;


// Ihre echten Namespaces einbinden
using KickBase.Analyzers;         // Hier sitzt Ihr Analyzer
using KickBase.Analyzers.Codefixes;
using KickBase.Domain;
using Microsoft.CodeAnalysis; // Hier sitzt Ihr CodeFix

namespace KickBase.Tests;

public class PropertyMeaningTests
{
    [Fact]
    public async Task Check_For_Missing_Attributes_Async()
    {
        // Das [| ... |] markiert die Stelle, an der Ihr Analyzer KB1000 auslöst
        var beforAnalyer = @"
                                using KickBase.Domain;
                                namespace Test;
                                [KickBaseApi]
                                public class MyClass
                                {
                                     public string MyProperty { get; set; }
                                }";

        var codeFixed = @"
                                using KickBase.Domain;
                                namespace Test;
                                [KickBaseApi]
                                public class MyClass
                                {
                                    [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
                                    public string MyProperty { get; set; }
                                }";

        // Ersetzen Sie 'KickBaseAnalyzer' durch den echten Namen Ihrer Analyzer-Klasse
        var test = new CSharpCodeFixTest<KickBasePropertyMeaningAnalyzer, KickBasePropertyMeaningCodeFixProvider, DefaultVerifier>
        {
            TestCode = beforAnalyer,
            FixedCode = codeFixed,
            ReferenceAssemblies = ReferenceAssemblies.Net.Net100
        };

        test.SolutionTransforms.Add((solution, projectId) =>
        {
            // Typen aus der Assembly auslesen, in der Ihr echtes Attribut definiert ist
            // Ersetzen Sie 'KickBaseApiAttribute' durch den echten Typen aus Ihrem Projekt
            var assemblyLocation = typeof(KickBaseApi).Assembly.Location;
            
            var project = solution.GetProject(projectId);
            project = project!.AddMetadataReference(MetadataReference.CreateFromFile(assemblyLocation));
            
            return project.Solution;
        });
        
        test.ExpectedDiagnostics.Add( DiagnosticResult
            .CompilerWarning("KB1000")
            .WithSpan(7, 52, 7, 62)
            .WithArguments("MyProperty", "MyClass"));

        // Test starten
        await test.RunAsync();
    }
}