using System.Collections.Immutable;
using System.Composition;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Document = Microsoft.CodeAnalysis.Document;
using Formatter = Microsoft.CodeAnalysis.Formatting.Formatter;

namespace KickBase.Analyzers.Codefixes;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(KickBasePropertyMeaningCodeFixProvider)), Shared]
public sealed class KickBasePropertyMeaningCodeFixProvider : CodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds { get; }
        = ["KB1000"];

    public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken);
        var diagnostic = context.Diagnostics[0];
        var node = root?.FindNode(diagnostic.Location.SourceSpan);

        if (node is not PropertyDeclarationSyntax propertyDecl)
            return;

        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Add [KickBasePropertyMeaning(Unknown)]",
                createChangedDocument: ct => AddAttributeAsync(context.Document, propertyDecl, ct),
                equivalenceKey: "AddKickBasePropertyMeaning"),
            diagnostic);
    }

    private static async Task<Document> AddAttributeAsync(
        Document document, PropertyDeclarationSyntax propertyDecl, System.Threading.CancellationToken ct)
    {
        var root = await document.GetSyntaxRootAsync(ct);
        
        var attribute = SyntaxFactory.Attribute(
            SyntaxFactory.ParseName("KickBasePropertyMeaning"),
            SyntaxFactory.AttributeArgumentList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxFactory.AttributeArgument(
                        SyntaxFactory.ParseExpression("KickbasePropertyMeaning.Unknown")
                    )
                )
            )
        );

        var newAttrList = SyntaxFactory.AttributeList(SyntaxFactory.SingletonSeparatedList(attribute));
        var newProperty = propertyDecl.AddAttributeLists(newAttrList).WithAdditionalAnnotations(Formatter.Annotation);

        var newRoot = root!.ReplaceNode(propertyDecl, newProperty);
        return document.WithSyntaxRoot(newRoot);
    }
}