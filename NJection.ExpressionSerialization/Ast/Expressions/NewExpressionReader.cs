using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NJection.Extensions;
using NJection.ExpressionSerialization.Ast.Configuration;
using System.Reflection;

namespace NJection.ExpressionSerialization.Ast.Expressions
{
    public partial class NewExpressionReader
    {
        private ConstructorInfo _constructor = null;
        private List<ParameterExpression> _arguments = null;

        partial void ReadConfiguration(NewExpressionConfiguration configuration) {
            Type[] types = new Type[configuration.arguments.Count];

            _arguments = new List<ParameterExpression>(configuration.arguments.Count);
            InternalType = Type.GetType(configuration.type);
            
            configuration.arguments
                         .ForEach((a, i) => {
                             var parameter = a.Accept(Scope, Visitor)
                                              .Reduce() as ParameterExpression;

                             _arguments.Add(parameter);
                             types[i] = parameter.Type;
                         });

            _constructor = InternalType.GetConstructor(ReflectionUtils.AllFlags, Type.DefaultBinder, types, null);
        }

        public IEnumerable<ParameterExpression> Parameters {
            get {
                return _arguments;
            }
        }

        public override Expression Reduce() {
            if (_arguments.Count == 0){
                return Expression.New(_constructor);
            }

            return Expression.New(_constructor, _arguments);
        }
    }
}
