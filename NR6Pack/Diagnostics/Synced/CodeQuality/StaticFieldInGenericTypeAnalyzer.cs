//
// StaticFieldInGenericTypeAnalyzer.cs
//
// Author:
//       Simon Lindgren <simon.n.lindgren@gmail.com>
//
// Copyright (c) 2012 Simon Lindgren
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CodeFixes;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.Text;
using System.Threading;
using ICSharpCode.NRefactory6.CSharp.Refactoring;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.FindSymbols;

namespace ICSharpCode.NRefactory6.CSharp.Diagnostics
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
    [NotPortedYet]
    public class StaticFieldInGenericTypeAnalyzer : DiagnosticAnalyzer
	{
		static readonly DiagnosticDescriptor descriptor = new DiagnosticDescriptor (
			NRefactoryDiagnosticIDs.StaticFieldInGenericTypeAnalyzerID, 
			GettextCatalog.GetString("Warns about static fields in generic types"),
			GettextCatalog.GetString("Static field in generic type"), 
			DiagnosticAnalyzerCategories.CodeQualityIssues, 
			DiagnosticSeverity.Warning, 
			isEnabledByDefault: true,
			helpLinkUri: HelpLink.CreateFor(NRefactoryDiagnosticIDs.StaticFieldInGenericTypeAnalyzerID)
		);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create (descriptor);

		public override void Initialize(AnalysisContext context)
		{
			//context.RegisterSyntaxNodeAction(
			//	(nodeContext) => {
			//		Diagnostic diagnostic;
			//		if (TryGetDiagnostic (nodeContext, out diagnostic)) {
			//			nodeContext.ReportDiagnostic(diagnostic);
			//		}
			//	}, 
			//	new SyntaxKind[] { SyntaxKind.None }
			//);
		}

		static bool TryGetDiagnostic (SyntaxNodeAnalysisContext nodeContext, out Diagnostic diagnostic)
		{
			diagnostic = default(Diagnostic);
			if (nodeContext.IsFromGeneratedCode())
				return false;
			//var node = nodeContext.Node as ;
			//diagnostic = Diagnostic.Create (descriptor, node.GetLocation ());
			//return true;
			return false;
		}

//		class GatherVisitor : GatherVisitorBase<StaticFieldInGenericTypeAnalyzer>
//		{
//			public GatherVisitor(SemanticModel semanticModel, Action<Diagnostic> addDiagnostic, CancellationToken cancellationToken)
//				: base (semanticModel, addDiagnostic, cancellationToken)
//			{
//			}

////			IList<ITypeParameter> availableTypeParameters = new List<ITypeParameter>();
////
////			public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
////			{
////				var typeResolveResult = ctx.Resolve(typeDeclaration);
////				var typeDefinition = typeResolveResult.Type.GetDefinition();
////				if (typeDefinition == null)
////					return;
////				var newTypeParameters = typeDefinition.TypeParameters;
////
////				var oldTypeParameters = availableTypeParameters; 
////				availableTypeParameters = Concat(availableTypeParameters, newTypeParameters);
////
////				base.VisitTypeDeclaration(typeDeclaration);
////
////				availableTypeParameters = oldTypeParameters;
////			}
////
////			static IList<ITypeParameter> Concat(params IList<ITypeParameter>[] lists)
////			{
////				return lists.SelectMany(l => l).ToList();
////			}
////
////			bool UsesAllTypeParameters(FieldDeclaration fieldDeclaration)
////			{
////				if (availableTypeParameters.Count == 0)
////					return true;
////
////				var fieldType = ctx.Resolve(fieldDeclaration.ReturnType).Type as ParameterizedType;
////				if (fieldType == null)
////					return false;
////
////				// Check that all current type parameters are used in the field type
////				var fieldTypeParameters = fieldType.TypeArguments;
////				foreach (var typeParameter in availableTypeParameters) {
////					if (!fieldTypeParameters.Contains(typeParameter))
////						return false;
////				}
////				return true;
////			}
////
////			public override void VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
////			{
////				base.VisitFieldDeclaration(fieldDeclaration);
////				if (fieldDeclaration.Modifiers.HasFlag(Modifiers.Static) && !UsesAllTypeParameters(fieldDeclaration)) {
//			//					AddDiagnosticAnalyzer(new CodeIssue(fieldDeclaration, ctx.TranslateString("Static field in generic type")));
////				}
////			}
//		}
	}
}