using System;
using System.Linq;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Expressions;

namespace NJection.ExpressionSerialization.Ast.Visitors
{
	public partial interface IConfigurationVisitor
	{
		Expression Visit(IScope scope, LambdaExpressionConfiguration configuration);
		Expression Visit(IScope scope, ConstantExpressionConfiguration configuration);
		Expression Visit(IScope scope, NewExpressionConfiguration configuration);
		Expression Visit(IScope scope, ParameterExpressionConfiguration configuration);
	}
	
	public class ConfigurationVisitor : IConfigurationVisitor
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
	}
}
