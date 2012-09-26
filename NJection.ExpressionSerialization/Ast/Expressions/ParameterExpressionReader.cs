using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NJection.ExpressionSerialization.Ast.Configuration;
using System.Linq.Expressions;

namespace NJection.ExpressionSerialization.Ast.Expressions
{
    public partial class ParameterExpressionReader
    {
        private ParameterExpression _parameter = null;

        partial void ReadConfiguration(ParameterExpressionConfiguration configuration) {
            if (!string.IsNullOrEmpty(configuration.@ref)) {
                _parameter = Scope.Find(configuration.@ref);
            }
            else {
                InternalType = Type.GetType(configuration.type);
                Name = configuration.name;
                _parameter = Expression.Parameter(InternalType, Name);
            }
        }

        public string Name { get; set; }

        public override Expression Reduce() {
            return _parameter;
        }
    }
}
