using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NJection.ExpressionSerialization.Ast.Configuration;
using System.Reflection;
using System.Linq.Expressions;

namespace NJection.ExpressionSerialization.Ast.Expressions
{
    public partial class ConstantExpressionReader
    {
        private object _value = null;
        private ConstructorInfo _ctor = null;

        partial void ReadConfiguration(ConstantExpressionConfiguration configuration) {
            _value = configuration.value;
            InternalType = Type.GetType(configuration.type);
            _ctor = InternalType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, CallingConventions.HasThis, new Type[] { }, null);
        }

        public override System.Linq.Expressions.Expression Reduce() {
            if (_ctor != null) {
                return Expression.Constant(Activator.CreateInstance(InternalType), InternalType);
            }

            return Expression.Constant(System.Convert.ChangeType(_value, InternalType), InternalType);
        }
    }
}
