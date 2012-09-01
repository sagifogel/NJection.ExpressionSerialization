using System;
using System.Linq.Expressions;
using System.Linq;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Expressions;

namespace NJection.ExpressionSerialization.Ast.Visitors
{
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
