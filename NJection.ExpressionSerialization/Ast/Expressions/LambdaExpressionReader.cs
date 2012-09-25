using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NJection.ExpressionSerialization.Ast.Configuration;
using System.Linq.Expressions;
using NJection.Extensions;

namespace NJection.ExpressionSerialization.Ast.Expressions
{
    public partial class LambdaExpressionReader
    {
        private List<ParameterExpression> _parameters = null;

        partial void ReadConfiguration(LambdaExpressionConfiguration configuration) {
            InternalType = Type.GetType(configuration.type);
            Name = configuration.name;
            _parameters = new List<ParameterExpression>(configuration.arguments.Count);
          
            configuration.arguments
                         .ForEach(a => {
                             var parameter = a.Accept(this, Visitor).ReduceExtensions() as ParameterExpression;
                             var variable = new Variable(parameter);

                             VariablesStore.Add(variable.Expression.Name, variable);
                             _parameters.Add(parameter);
                         });

            Body = configuration.expression.Accept(this, Visitor);
        }

        internal string Name { get; private set; } 

        internal Expression Body { get; private set; } 

        internal IEnumerable<ParameterExpression> Parameters {
            get {
                return _parameters;
            }
        }

        public override Expression Reduce() {
            return Expression.Lambda(Body, _parameters);
        }
    }
}
