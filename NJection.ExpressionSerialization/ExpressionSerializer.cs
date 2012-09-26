using System.Linq.Expressions;
using NJection.Core;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Expressions;
using NJection.ExpressionSerialization.Ast.Visitors;
using NJection.ExpressionSerialization.Visitors;

namespace NJection.ExpressionSerialization
{
    public class ExpressionSerializer
    {
        public Expression<TDelegate> Deserialize<[DelegateConstraintAttribute]TDelegate>(string filePath) where TDelegate : class {
            var configuration = njection_configuration.LoadFromFile(filePath);

            return Deserialize<TDelegate>(configuration);
        }

        public Expression<TDelegate> DeserializeXml<[DelegateConstraintAttribute]TDelegate>(string xml) where TDelegate : class {
            var configuration = njection_configuration.Deserialize(xml);
            
            return Deserialize<TDelegate>(configuration);
        }

        private Expression<TDelegate> Deserialize<[DelegateConstraintAttribute]TDelegate>(njection_configuration configuration) where TDelegate : class {
            var visitor = new ExpressionConfigurationVisitor();
            var lambda = configuration.lambda.Accept(null, visitor) as LambdaExpressionReader;

            return Expression.Lambda<TDelegate>(lambda.Body, lambda.Name, lambda.Parameters);
        }

        public string Serialize(LambdaExpression lambda) {
            var serializer = new SerializerVisitor();
            var configuration = new njection_configuration{
                lambda = serializer.Visit(lambda)
            };
            
            return configuration.Serialize();
        }
    }
}
