﻿// 
// ConvertCastToAsAction.cs
//  
// Author:
//       Mansheng Yang <lightyang0@gmail.com>
// 
// Copyright (c) 2012 Mansheng Yang <lightyang0@gmail.com>
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
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	/// <summary>
	/// Converts a cast expression to an 'as' expression
	/// </summary>
	[ContextAction ("Convert cast to 'as'.", Description = "Convert cast to 'as'.")]
	public class ConvertCastToAsAction : ICodeActionProvider
	{
		public IEnumerable<CodeAction> GetActions (RefactoringContext context)
		{
			var castExpr = GetCastExpression (context);
			if (castExpr != null) {
				yield return new CodeAction ("Convert cast to 'as'.", script => 
					script.Replace (castExpr, new AsExpression (castExpr.Expression.Clone (), castExpr.Type.Clone ())));
			}
		}

		static CastExpression GetCastExpression (RefactoringContext context)
		{
			var castExpr = context.GetNode<CastExpression> ();
			if (castExpr == null)
				return null;

			var typeResolveResult = context.Resolve (castExpr.Type);
			if (typeResolveResult == null)
				return null;

			// only works on reference and nullable types
			var type = typeResolveResult.Type;
			if ((!(type.IsReferenceType ?? true)) && type.FullName != "System.Nullable")
				return null;

			return castExpr;
		}
	}
}
