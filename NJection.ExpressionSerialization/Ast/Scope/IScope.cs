using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NJection.ExpressionSerialization.Ast
{
    public interface IScope : IScopeChild
    {
        ParameterExpression Find(string name);
        Variable FindVariable(string name);
        IEnumerable<ParameterExpression> Variables { get; }
    }
}