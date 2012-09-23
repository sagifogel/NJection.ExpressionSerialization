using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Visitors;

namespace NJection.ExpressionSerialization.Ast.Expressions
{
    public abstract class Scope : AbstractExpression, IScope
    {
        public Scope(IScope scope, IExpressionConfigurationVisitor visitor)
            : base(scope, visitor) {
            
            VariablesStore = new Dictionary<string, Variable>();

            if (scope != null) {
                ParentScope = scope;
                RootScope = ParentScope.RootScope;
            }
        }

        #region IScope Members

        public IScope ParentScope { get; set; }

        public IMethodScope RootScope { get; set; }

        protected IDictionary<string, Variable> VariablesStore { get; set; }

        public IEnumerable<ParameterExpression> Variables {
            get {
                return VariablesStore.Values.Select(v => v.Expression);
            }
        }

        public ParameterExpression Find(string name) {
            Variable variable = FindVariable(name);

            if (variable != null) {
                return variable.Expression;
            }

            return null;
        }

        protected virtual bool TryFind(string name, out Variable variableData) {
            return VariablesStore.TryGetValue(name, out variableData);
        }

        protected virtual bool TryFind(string name, out ParameterExpression expression) {
            Variable variable;

            if (VariablesStore.TryGetValue(name, out variable)) {
                expression = variable.Expression;
                return true;
            }

            expression = null;
            return false;
        }

        private Variable FindInParentScopes(string name, IScope scope) {
            Variable variable = null;

            while (scope != null) {
                variable = scope.FindVariable(name);

                if (variable != null) {
                    return variable;
                }

                scope = scope.ParentScope;
            }

            return null;
        }

        public Variable FindVariable(string name) {
            Variable variable = null;

            if (TryFind(name, out variable)) {
                return variable;
            }

            return FindInParentScopes(name, ParentScope);
        }

        public virtual Type ResolveType(string genericType) {
            return null;
        }

        #endregion IScope Members
    }
}