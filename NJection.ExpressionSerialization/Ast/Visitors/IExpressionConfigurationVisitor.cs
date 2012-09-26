using System;
using System.Linq;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Expressions;
using NJection.Scope;

namespace NJection.ExpressionSerialization.Ast.Visitors
{
	public partial interface IExpressionConfigurationVisitor
	{
		Expression Visit(IScope scope, LambdaExpressionConfiguration configuration);
		Expression Visit(IScope scope, ConstantExpressionConfiguration configuration);
		Expression Visit(IScope scope, NewExpressionConfiguration configuration);
		Expression Visit(IScope scope, ParameterExpressionConfiguration configuration);
	}
}
