using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NJection.ExpressionSerialization.Ast.Configuration;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Extensions;

namespace NJection.ExpressionSerialization.Ast.Expressions
{
    public partial class LambdaExpressionReader
    {
        private Expression _body = null;
        private List<ParameterExpression> _parameters = null;

        partial void ReadConfiguration(LambdaExpressionConfiguration configuration) {
            InternalType = Type.GetType(configuration.type);
            _parameters = new List<ParameterExpression>(configuration.arguments.Count);

            configuration.arguments
                         .ForEach(a => {
                             var parameter = a.Accept(this, Visitor).ReduceExtensions() as ParameterExpression;
                             var variable = new Variable(parameter);

                             VariablesStore.Add(variable.Expression.Name, variable);
                             _parameters.Add(parameter);
                         });

            _body = configuration.expression.Accept(this, Visitor);
        }

        public IEnumerable<ParameterExpression> Parameters {
            get {
                return _parameters;
            }
        }

        public override Expression Reduce() {
            return Expression.Lambda(_body, _parameters);
        }

        public TDelegate Compile<TDelegate>() where TDelegate : class {
            var lambda = Reduce() as LambdaExpression;

            return lambda.Compile() as TDelegate;
        }
    }
}
