using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NJection.ExpressionSerialization.Extensions;
using NJection.ExpressionSerialization.Ast.Configuration;

namespace NJection.ExpressionSerialization.Ast.Visitors
{
    public class SerializerVisitor : ISerializerVisitor
    {
        public LambdaExpressionConfiguration Visit(LambdaExpression lambdaExpression) {
            return new LambdaExpressionConfiguration {
                arguments = lambdaExpression.Parameters.Select(p => Visit(p)).ToList(),
                expression = Visit(lambdaExpression.Body),
                name = lambdaExpression.Name
            };
        }

        public ConstantExpressionConfiguration Visit(ConstantExpression constantExpression) {
            throw new NotImplementedException();
        }

        public NewExpressionConfiguration Visit(NewExpression newExpression) {
            throw new NotImplementedException();
        }

        public ParameterExpressionConfiguration Visit(ParameterExpression parameterExpression) {
            throw new NotImplementedException();
        }

        public ExpressionConfiguration Visit(Expression expression) {
            throw new NotImplementedException();
        }
    }
}
