using System;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Visitors;

namespace NJection.ExpressionSerialization.Ast.Visitors
{
	public interface ISerializerVisitor
	{
		LambdaExpressionConfiguration Visit(LambdaExpression lambdaExpression);
		ConstantExpressionConfiguration Visit(ConstantExpression constantExpression);
		NewExpressionConfiguration Visit(NewExpression newExpression);
		ParameterExpressionConfiguration Visit(ParameterExpression parameterExpression);
	}
}
