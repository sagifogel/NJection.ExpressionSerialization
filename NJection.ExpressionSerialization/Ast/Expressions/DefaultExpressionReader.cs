using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NJection.ExpressionSerialization.Ast.Configuration;
using System.Linq.Expressions;

namespace NJection.ExpressionSerialization.Ast.Expressions
{
    public partial class DefaultExpressionReader
    {   
        partial void ReadConfiguration(DefaultExpressionConfiguration configuration) {
            InternalType = Type.GetType(configuration.type);
        }

        public override Expression Reduce() {
            return Expression.Default(InternalType);
        }
    }
}
