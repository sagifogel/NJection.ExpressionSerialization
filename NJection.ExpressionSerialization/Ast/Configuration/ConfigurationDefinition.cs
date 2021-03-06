using System;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Visitors;
using NJection.Scope;

namespace NJection.ExpressionSerialization.Ast.Configuration
{	
	public partial class LambdaExpressionConfiguration 
	{
		internal override Expression Accept(IScope scope, IExpressionConfigurationVisitor visitor) {
            return visitor.Visit(scope, this);
        }
	}
	
	public partial class ConstantExpressionConfiguration 
	{
		internal override Expression Accept(IScope scope, IExpressionConfigurationVisitor visitor) {
            return visitor.Visit(scope, this);
        }
	}
	
	public partial class NewExpressionConfiguration 
	{
		internal override Expression Accept(IScope scope, IExpressionConfigurationVisitor visitor) {
            return visitor.Visit(scope, this);
        }
	}
	
	public partial class ParameterExpressionConfiguration 
	{
		internal override Expression Accept(IScope scope, IExpressionConfigurationVisitor visitor) {
            return visitor.Visit(scope, this);
        }
	}
	
	public partial class DefaultExpressionConfiguration 
	{
		internal override Expression Accept(IScope scope, IExpressionConfigurationVisitor visitor) {
            return visitor.Visit(scope, this);
        }
	}
	
	public partial class InvokeExpressionConfiguration 
	{
		internal override Expression Accept(IScope scope, IExpressionConfigurationVisitor visitor) {
            return visitor.Visit(scope, this);
        }
	}
}
