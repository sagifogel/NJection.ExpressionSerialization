using System.Linq.Expressions;

namespace NJection.Core
{
    public class Variable
    {
        public Variable(ParameterExpression expression) {
            Expression = expression;
        }

        public ParameterExpression Expression { get; private set; }
    }
}