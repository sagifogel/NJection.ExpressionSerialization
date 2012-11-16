using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NJection.ExpressionSerialization.Ast.Configuration;
using System.Linq.Expressions;
using System.Diagnostics.Contracts;

namespace NJection.ExpressionSerialization.Ast.Expressions
{
    public partial class InvokeExpressionReader
    {
        private Expression _expression = null;
        private IEnumerable<Expression> _arguments = null;

        partial void ReadConfiguration(InvokeExpressionConfiguration configuration) {
             _expression = configuration.expression.Accept(Scope, Visitor);
             _arguments = configuration.arguments.Select(a => a.Accept(Scope, Visitor));
             InternalType = Type.GetType(configuration.type);
                
            Contract.Assert(InternalType.Equals(GetReturnType(_expression.Type)));
        }

        private Type GetReturnType(Type type) {
            var genericArguments = type.GetGenericArguments();
            var funcTypeDefinition = Expression.GetFuncType(genericArguments);

            if (funcTypeDefinition.Equals(type)) {
                return genericArguments[genericArguments.Length - 1];
            }

            return typeof(void);
        }

        public override Expression Reduce() {
            return Expression.Invoke(_expression, _arguments);
        }
    }
}
