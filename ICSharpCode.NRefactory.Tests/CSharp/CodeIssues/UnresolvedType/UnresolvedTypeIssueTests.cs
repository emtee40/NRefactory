using ICSharpCode.NRefactory.CSharp.CodeIssues;
using NUnit.Framework;
using ICSharpCode.NRefactory.CSharp.CodeActions;
using ICSharpCode.NRefactory.CSharp.Refactoring;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.CodeIssues.UnresolvedType
{
	[TestFixture]
	public class UnresolvedTypeIssueTests : InspectionActionTestBase
	{
		#region Field Declarations
		[Test]
		public void ShouldReturnAnIssueForUnresolvedFieldDeclarations()
		{
			this.ShouldNotBeAbleToResolve(@"class Foo
{
	private TextWriter textWriter;

	void Bar ()
	{
		textWriter.WriteLine();
	}
}", "System.IO");
		}

		[Test]
		public void ShouldNotReturnAnyIssuesIfFieldTypeIsResolved()
		{
			this.ShouldBeAbleToResolve(@"using System.IO;

class Foo
{
	private TextWriter textWriter;

	void Bar ()
	{
		textWriter.WriteLine();
	}
}");
		}

		[Test]
		public void ShouldReturnAnIssueIfFieldTypeArgumentIsNotResolvable()
		{
			this.ShouldNotBeAbleToResolve(
@"using System.Collections.Generic;

class Foo
{
	private List<AttributeTargets> targets;
}", "System");
		}

		[Test]
		public void ShouldNotReturnAnIssueIfFieldTypeArgumentIsResolvable()
		{
			this.ShouldBeAbleToResolve(
@"using System.Collections.Generic;

class Foo
{
	private List<string> notifiers;
}");
		}
		#endregion

		#region Method Return Types
		[Test]
		public void ShouldReturnIssueForUnresolvedReturnType()
		{
			this.ShouldNotBeAbleToResolve(
@"class Foo
{
	TextWriter Bar ()
	{
		return null;
	}
}", "System.IO");
		}

		[Test]
		public void ShouldNotReturnIssueForResolvedReturnType()
		{
			this.ShouldBeAbleToResolve(
@"using System.IO;

class Foo
{
	TextWriter Bar ()
	{
		return null;
	}
}");
		}

		[Test]
		public void ShouldReturnIssueForUnresolvedReturnTypeArguments()
		{
			this.ShouldNotBeAbleToResolve(
@"using System.Collections.Generic;
class Foo
{
	List<AttributeTargets> GetTargets()
	{
		return null;
	}
}", "System");
		}

		[Test]
		public void ShouldNotReturnIssueForResolvedReturnTypeArguments()
		{
			this.ShouldBeAbleToResolve(
@"using System.Collections.Generic;
class Foo
{
	List<string> GetStrings()
	{
		return null;
	}
}");
		}
		#endregion

		#region Local Variables
		[Test]
		public void ShouldReturnIssueForUnresolvedLocalVariableDeclaration()
		{
			this.ShouldNotBeAbleToResolve(
@"class Foo
{
	void Bar ()
	{
		TextWriter writer;
	}
}", "System.IO");
		}

		[Test]
		public void ShouldNotReturnIssueForResolvedLocalVariableDeclaration()
		{
			this.ShouldBeAbleToResolve(
@"using System.IO;

class Foo
{
	void Bar ()
	{
		TextWriter writer;
	}
}");
		}

		[Test]
		public void ShouldReturnIssueForUnresolvedLocalVariableTypeArguments()
		{
			this.ShouldNotBeAbleToResolve(
@"using System.Collections.Generic;

class Foo
{
	void Bar ()
	{
		List<AttributeTargets> targets;
	}
}", "System");
		}
		#endregion

		#region Method Parameters
		[Test]
		public void ShouldReturnIssueIfMethodParameterIsNotResolvable()
		{
			this.ShouldNotBeAbleToResolve(
@"class Foo
{
	void Bar (TextWriter writer)
	{
	}
}", "System.IO");
		}

		[Test]
		public void ShouldNotReturnAnIssueIfMethodParameterIsResolvable()
		{
			this.ShouldBeAbleToResolve(
@"using System.IO;

class Foo
{
	void Bar (TextWriter writer)
	{
	}
}");
		}

		[Test]
		public void ShouldReturnIssueIfMethodParameterTypeArgumentIsNotResolvable()
		{
			this.ShouldNotBeAbleToResolve(
@"using System.Collections.Generic;
class Foo
{
	void Bar (List<AttributeTargets> targets)
	{
	}
}", "System");
		}

		[Test]
		public void ShouldNotReturnIssueIfMethodParameterTypeArgumentsAreResolvable()
		{
			this.ShouldBeAbleToResolve(
@"using System.Collections.Generic;
class Foo
{
	void Bar (List<string> strings)
	{
	}
}");
		}
		#endregion

		#region Base Types
		[Test]
		public void ShouldReturnIssueIfBaseClassIsNotResolvable()
		{
			this.ShouldNotBeAbleToResolve(
@"class Foo : List<string>
{
}", "System.Collections.Generic");
		}

		[Test]
		public void ShouldNotReturnIssueIfBaseClassIsResolvable()
		{
			this.ShouldBeAbleToResolve(
@"using System.Collections.Generic;

class Foo : List<string>
{
}");
		}

		[Test]
		public void ShouldReturnIssueIfBaseClassTypeArgumentIsNotResolvable()
		{
			this.ShouldNotBeAbleToResolve(
@"using System.Collections.Generic;
class Foo : List<AttributeTargets>
{
}", "System");
		}
		#endregion

		#region Type Casting
		[Test]
		public void ShouldReturnIssueIfTypeCastIsNotResolvable()
		{
			this.ShouldNotBeAbleToResolve(
@"class Foo
{
	void Bar (object bigObject)
	{
		var notifier = (AttributeTargets)bigObject;
	}
}", "System");
		}

		[Test]
		public void ShouldNotReturnIssueIfTypeCastIsResolvable()
		{
			this.ShouldBeAbleToResolve(
@"class Foo
{
	void Bar (object bigObject)
	{
		var notifier = (string)bigObject;
	}
}");
		}

		[Test]
		public void ShouldReturnIssueIfAsExpressionIsNotResolvable()
		{
			this.ShouldNotBeAbleToResolve(
@"class Foo
{
	void Bar (object bigObject)
	{
		var writer = bigObject as TextWriter;
	}
}", "System.IO");
		}

		[Test]
		public void ShouldNotReturnIssueIfTypeInAsExpressionIsResolvable()
		{
			this.ShouldBeAbleToResolve(
@"class Foo
{
	void Bar (object bigObject)
	{
		var str = bigObject as string;
	}
}");
		}
		#endregion

		#region Member Access
		// TODO Debug me!!!

		[Test]
		public void ShouldReturnIssueIfEnumValueIsNotResolvable()
		{
			this.ShouldNotBeAbleToResolve(
@"class Foo
{
	void Bar ()
	{
		var support = AttributeTargets.Assembly;
	}
}", "System");
		}

		[Test]
		public void ShouldNotReturnIssueIfEnumValueIsResolvable()
		{
			this.ShouldBeAbleToResolve(
@"using System;
class Foo
{
	void Bar ()
	{
		var support = AttributeTargets.Assembly;
	}
}");
		}
		#endregion

		[Test]
		public void ShouldReturnIssueIfAttributeIsNotResolvable()
		{
			this.ShouldNotBeAbleToResolve(
@"[Serializable]
class Foo
{
}", "System");
		}

		[Test]
		public void ShouldNotReturnIssueIfAttributeIsResolvable()
		{
			this.ShouldBeAbleToResolve(
@"using System;

[Serializable]
class Foo
{
}");
		}

		[Test]
		public void ShouldReturnIssueIfTypeArgumentIsNotResolvable()
		{
			this.ShouldNotBeAbleToResolve(
@"using System.Collections.Generic;

class Test
{
	void TestMethod()
	{
		var list = new List<Stream>();
	}
}", "System.IO");
		}

		[Test]
		public void ShouldSupportMultipleIssues()
		{
			this.ShouldNotBeAbleToResolve(
@"class TestAttribute : Attribute
{
	private List<Stream> streams;
}", "System", "System.Collections.Generic", "System.IO");
		}

		[Test]
		public void ShouldReturnIssueForUnresolvedExtensionMethod()
		{
			this.ShouldNotBeAbleToResolve(
@"using System.Collections.Generic;

class Test
{
	void TestMethod()
	{
		var list = new List<string>();
		var first = list.First();
	}
}", "System.Linq");
		}

		[Test]
		public void ShouldReturnMultipleNamespaceSuggestions()
		{
			this.ShouldNotBeAbleToResolve(
@"namespace A { public class TestClass { } }
namespace B { public class TestClass { } }
namespace C
{
	public class Test
	{
		private TestClass testClass;
	}
}", "A", "B");
		}

		private void ShouldNotBeAbleToResolve(string testInput, params string[] newNamespaces)
		{
			// Arrange
			TestRefactoringContext context;

			// Act
			var issues = GetIssues(new UnresolvedTypeIssue(), testInput, out context);

			// Assert
			foreach (var issueNamespace in newNamespaces)
			{
				var foundIssue = issues.FirstOrDefault(i => i.Description == "using " + issueNamespace + ";");
				Assert.NotNull(foundIssue, "Could not find an issue for " + issueNamespace);
			}
		}

		private void ShouldBeAbleToResolve(string testInput)
		{
			// Arrange
			TestRefactoringContext context;

			// Act
			var issues = GetIssues(new UnresolvedTypeIssue(), testInput, out context);

			// Assert
			Assert.IsEmpty(issues);
		}
	}
}
