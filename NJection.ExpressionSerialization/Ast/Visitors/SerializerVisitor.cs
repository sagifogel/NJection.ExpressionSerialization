using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NJection.ExpressionSerialization.Ast.Configuration;

namespace NJection.ExpressionReader.Ast.Visitors
{
    public class SerializerVisitor : ExpressionVisitor
    {
        public SerializerVisitor(LambdaExpression lambda) {

        }

        internal LambdaExpressionConfiguration Seriailize() {
            return null;
        }
    }
}
