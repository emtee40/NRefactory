﻿// Copyright (c) 2010-2013 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Linq;
using NUnit.Framework;

namespace ICSharpCode.NRefactory.PlayScript.Parser.Statements
{
	[TestFixture]
	public class UsingStatementTests
	{
		[Test]
		public void UsingStatementWithVariableDeclaration()
		{
			ParseUtilCSharp.AssertStatement(
				"using (MyVar var = new MyVar()) { }",
				new UsingStatement {
					ResourceAcquisition = new VariableDeclarationStatement(
						new SimpleType("MyVar"),
						"var",
						new ObjectCreateExpression(new SimpleType("MyVar"))),
					EmbeddedStatement = new BlockStatement()
				});
		}
		
		[Test]
		public void UsingStatementWithMultipleVariableDeclaration()
		{
			ParseUtilCSharp.AssertStatement(
				"using (MyVar a = new MyVar(), b = null);",
				new UsingStatement {
					ResourceAcquisition = new VariableDeclarationStatement {
						Type = new SimpleType("MyVar"),
						Variables = {
							new VariableInitializer("a", new ObjectCreateExpression(new SimpleType("MyVar"))),
							new VariableInitializer("b", new NullReferenceExpression())
						}
					},
					EmbeddedStatement = new EmptyStatement()
				});
		}
		
		public void UsingStatementWithExpression()
		{
			ParseUtilCSharp.AssertStatement(
				"using (MyVar var = new MyVar()) { }",
				new UsingStatement {
					ResourceAcquisition = new ObjectCreateExpression(new SimpleType("MyVar")),
					EmbeddedStatement = new BlockStatement()
				});
		}
	}
}
