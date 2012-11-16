using System;
using System.Linq;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Expressions;
using NJection.Scope;

namespace NJection.ExpressionSerialization.Ast.Visitors
{
	public class ExpressionConfigurationVisitor : IExpressionConfigurationVisitor
    {
		public Expression Visit(IScope scope, LambdaExpressionConfiguration configuration) {
			return ExpressionReader.Lambda(configuration, scope, this);
		}

		public Expression Visit(IScope scope, ConstantExpressionConfiguration configuration) {
			return ExpressionReader.Constant(configuration, scope, this);
		}

		public Expression Visit(IScope scope, NewExpressionConfiguration configuration) {
			return ExpressionReader.New(configuration, scope, this);
		}

		public Expression Visit(IScope scope, ParameterExpressionConfiguration configuration) {
			return ExpressionReader.Parameter(configuration, scope, this);
		}

		public Expression Visit(IScope scope, DefaultExpressionConfiguration configuration) {
			return ExpressionReader.Default(configuration, scope, this);
		}

		public Expression Visit(IScope scope, InvokeExpressionConfiguration configuration) {
			return ExpressionReader.Invoke(configuration, scope, this);
		}
	}
}
