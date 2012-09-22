using NJection;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Expressions;
using NJection.ExpressionSerialization.Ast.Visitors;
using System;
using System.IO;
using NJection.ExpressionReader.Ast.Visitors;

namespace NJection.ExpressionSerialization
{
    public class ExpressionSerializer
    {
        public Expression<TDelegate> Deserialize<[DelegateConstraintAttribute]TDelegate>(string filePath) where TDelegate : class {
            var visitor = new ConfigurationVisitor();
            var configuration = njection_configuration.LoadFromFile(filePath);
            var lambda = configuration.lambda.Accept(null, visitor) as LambdaExpressionReader;

            return Expression.Lambda<TDelegate>(lambda.Body, lambda.Name, lambda.Parameters);
        }

        public LambdaExpressionConfiguration Serialize(LambdaExpression lambda) {
            var serializer = new SerializerVisitor(lambda);

            return serializer.Seriailize();
        }
    }
}
