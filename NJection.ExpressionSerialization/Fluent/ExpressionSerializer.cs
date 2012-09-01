using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Linq.Expressions;
using System.Xml.Linq;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Visitors;
using System.IO;
using NJection.ExpressionSerialization.Ast.Expressions;

namespace NJection.ExpressionSerialization
{
    public class ExpressionSerializer
    {
        public LambdaExpressionReader Deserialize(string filePath) {
            var visitor = new ConfigurationVisitor();
            var configuration = njection_configuration.LoadFromFile(filePath);

            return configuration.lambda.Accept(null, visitor) as LambdaExpressionReader;
        }
    }
}
