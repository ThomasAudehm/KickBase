using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace KickBase.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class KickBasePropertyMeaningAnalyzer : DiagnosticAnalyzer
{
    private const string KickBaseApiAttributeName = "KickBaseApi";
    private const string KickBasePropertyMeaningAttributeName = "KickBasePropertyMeaning";

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; }
        = [DiagnosticDescriptors.MissingPropertyMeaning];

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterSymbolAction(AnalyzeNamedType, SymbolKind.NamedType);
    }

    private static void AnalyzeNamedType(SymbolAnalysisContext context)
    {
        var classSymbol = (INamedTypeSymbol)context.Symbol;

        if (classSymbol.TypeKind != TypeKind.Class)
            return;

        // Hat die Klasse [KickBaseApi]?
        var hasKickBaseApi = classSymbol.GetAttributes()
            .Any(a => a.AttributeClass is not null && a.AttributeClass.Name.StartsWith(KickBaseApiAttributeName));

            if (!hasKickBaseApi)
            return;

        foreach (var member in classSymbol.GetMembers())
        {
            if (member is not IPropertySymbol property)
                continue;

            // Indexer, geerbte/überschriebene Properties etc. ggf. ausschließen
            if (property.IsIndexer)
                continue;

            var hasMeaning = property.GetAttributes()
                .Any(a => a.AttributeClass is not null && a.AttributeClass.Name.StartsWith(KickBasePropertyMeaningAttributeName));

            if (hasMeaning)
                continue;

            // Report über die Property-Deklaration (erste Syntax-Referenz)
            var location = property.Locations.FirstOrDefault() ?? Location.None;

            context.ReportDiagnostic(Diagnostic.Create(
                DiagnosticDescriptors.MissingPropertyMeaning,
                location,
                property.Name,
                classSymbol.Name));
        }
    }
}