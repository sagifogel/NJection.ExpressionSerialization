﻿using System;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Visitors;

namespace NJection.ExpressionSerialization.Ast.Expressions
{
	public abstract class ExpressionReader : Expression
	{
		public static Expression Lambda(LambdaExpressionConfiguration configuration, IScope scope, IConfigurationVisitor visitor) {
			return new LambdaExpressionReader(configuration, scope, visitor);
		}

		public static Expression Constant(ConstantExpressionConfiguration configuration, IScope scope, IConfigurationVisitor visitor) {
			return new ConstantExpressionReader(configuration, scope, visitor);
		}

		public static Expression New(NewExpressionConfiguration configuration, IScope scope, IConfigurationVisitor visitor) {
			return new NewExpressionReader(configuration, scope, visitor);
		}

		public static Expression Parameter(ParameterExpressionConfiguration configuration, IScope scope, IConfigurationVisitor visitor) {
			return new ParameterExpressionReader(configuration, scope, visitor);
		}
	}
}