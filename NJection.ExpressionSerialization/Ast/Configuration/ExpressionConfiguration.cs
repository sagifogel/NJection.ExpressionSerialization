using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Visitors;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.Scope;

namespace NJection.ExpressionSerialization.Ast.Configuration
{
    public abstract partial class ExpressionConfiguration : Expression
    {
        internal abstract Expression Accept(IScope scope, IExpressionConfigurationVisitor visitor);

        public override bool CanReduce {
            get {
                return false;
            }
        }

        public override ExpressionType NodeType {
            get {
                return ExpressionType.Extension;
            }
        }
        
    }
}
