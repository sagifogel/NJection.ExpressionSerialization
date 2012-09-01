using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Visitors;
using NJection.ExpressionSerialization.Ast.Configuration;

namespace NJection.ExpressionSerialization.Ast.Configuration
{
    public abstract partial class ExpressionConfiguration
    {
        internal abstract Expression Accept(IScope scope, IConfigurationVisitor visitor);
    }
}
