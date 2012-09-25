using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NJection.Extensions;
using NJection.ExpressionSerialization.Ast.Configuration;

namespace NJection.ExpressionSerialization.Visitors
{
    public class SerializerVisitor : ExpressionVisitor
    {
        public LambdaExpressionConfiguration Visit(LambdaExpression lambdaExpression) {
            return new LambdaExpressionConfiguration {
                type = lambdaExpression.Type.GetQualifiedName(),
                arguments = lambdaExpression.Parameters.Select(p => Visit(p) as ParameterExpressionConfiguration).ToList(),
                expression = Visit(lambdaExpression.Body) as ExpressionConfiguration,
                name = lambdaExpression.Name
            };
        }

        public ConstantExpressionConfiguration Visit(ConstantExpression constantExpression) {
            throw new NotImplementedException();
        }

        protected override Expression VisitNew(NewExpression node) {
            var arguments = node.Arguments.Cast<ParameterExpression>()
                                          .Select(a => Visit(a))
                                          .ToListOf<ParameterExpressionConfiguration>();

            return new NewExpressionConfiguration {
                arguments = arguments,
                type = node.Type.GetQualifiedName()
            };
        }

        protected override Expression VisitParameter(ParameterExpression node) {
            return new ParameterExpressionConfiguration {
                name = node.Name,
                type = node.Type.GetQualifiedName()
            };
        }
    }
}
