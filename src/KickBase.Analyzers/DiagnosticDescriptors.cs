using Microsoft.CodeAnalysis;

namespace KickBase.Analyzers;

public static class DiagnosticDescriptors
{
    public static readonly DiagnosticDescriptor MissingPropertyMeaning = new(
        id: "KB1000",
        title: "Property fehlt KickBasePropertyMeaningAttribute",
        messageFormat: "Property '{0}' in Klasse '{1}' (mit [KickBaseApi]) hat kein [KickBasePropertyMeaning]-Attribut",
        category: "Design",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Alle Properties einer mit [KickBaseApi] markierten Klasse müssen mit [KickBasePropertyMeaning] dekoriert sein.");
}