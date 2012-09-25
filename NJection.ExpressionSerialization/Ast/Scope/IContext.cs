using System;
using System.Linq.Expressions;

namespace NJection.ExpressionSerialization.Ast
{
    public interface IContext
    {
        Type Type { get; }
        object Value { get; }
        Expression Expression { get; }
    }
}