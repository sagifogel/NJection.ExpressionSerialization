using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NJection.ExpressionSerialization
{
    public interface IScope : IScopeChild
    {
        ParameterExpression Find(string name);
        Variable FindVariable(string name);
        IEnumerable<ParameterExpression> Variables { get; }
    }
}