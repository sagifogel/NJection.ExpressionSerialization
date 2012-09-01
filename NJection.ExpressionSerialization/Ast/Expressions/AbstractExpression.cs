﻿using System;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Visitors;

namespace NJection.ExpressionSerialization.Ast.Expressions
{
    public abstract class AbstractExpression : ExpressionReader
    {
        protected internal AbstractExpression(IScope scope, IConfigurationVisitor visitor) {
            if (scope != null) {
                Scope = scope;
            }

            Visitor = visitor;
        }

        protected Type InternalType { get; set; }
        
        protected IScope Scope { get; private set; }
        
        protected IConfigurationVisitor Visitor { get; private set; }

        public override ExpressionType NodeType {
            get { return ExpressionType.Extension; }
        }

        public override bool CanReduce {
            get { return true; }
        }

        public override Type Type {
            get { return InternalType; }
        }

        #region Abstract

        protected abstract ExpressionType AstNodeType { get; }

        #endregion Abstract
    }
}