using System.Linq.Expressions;

namespace NJection.ExpressionSerialization
{
    public class Variable
    {
        public Variable(ParameterExpression expression) {
            Expression = expression;
        }

        public ParameterExpression Expression { get; private set; }
    }
}