using System;
using System.Linq.Expressions;
using NJection.ExpressionSerialization.Ast.Configuration;
using NJection.ExpressionSerialization.Ast.Visitors;
using NJection.Scope;

namespace NJection.ExpressionSerialization.Ast.Expressions
{	
	public partial class LambdaExpressionReader : Scope
	{	
		private LambdaExpressionConfiguration _configuration = null;

		internal LambdaExpressionReader(LambdaExpressionConfiguration configuration, IScope scope, IExpressionConfigurationVisitor visitor) 
			: base(scope, visitor) {

			_configuration = configuration;
			ReadConfiguration(configuration);	
		}
		
		partial void ReadConfiguration(LambdaExpressionConfiguration configuration);
		
		protected override ExpressionType AstNodeType {
            get { return ExpressionType.Lambda; }
        }
	}
	
	public partial class ConstantExpressionReader : AbstractExpression
	{	
		private ConstantExpressionConfiguration _configuration = null;

		internal ConstantExpressionReader(ConstantExpressionConfiguration configuration, IScope scope, IExpressionConfigurationVisitor visitor) 
			: base(scope, visitor) {

			_configuration = configuration;
			ReadConfiguration(configuration);	
		}
		
		partial void ReadConfiguration(ConstantExpressionConfiguration configuration);
		
		protected override ExpressionType AstNodeType {
            get { return ExpressionType.Constant; }
        }
	}
	
	public partial class NewExpressionReader : AbstractExpression
	{	
		private NewExpressionConfiguration _configuration = null;

		internal NewExpressionReader(NewExpressionConfiguration configuration, IScope scope, IExpressionConfigurationVisitor visitor) 
			: base(scope, visitor) {

			_configuration = configuration;
			ReadConfiguration(configuration);	
		}
		
		partial void ReadConfiguration(NewExpressionConfiguration configuration);
		
		protected override ExpressionType AstNodeType {
            get { return ExpressionType.New; }
        }
	}
	
	public partial class ParameterExpressionReader : AbstractExpression
	{	
		private ParameterExpressionConfiguration _configuration = null;

		internal ParameterExpressionReader(ParameterExpressionConfiguration configuration, IScope scope, IExpressionConfigurationVisitor visitor) 
			: base(scope, visitor) {

			_configuration = configuration;
			ReadConfiguration(configuration);	
		}
		
		partial void ReadConfiguration(ParameterExpressionConfiguration configuration);
		
		protected override ExpressionType AstNodeType {
            get { return ExpressionType.Parameter; }
        }
	}
	
	public partial class DefaultExpressionReader : AbstractExpression
	{	
		private DefaultExpressionConfiguration _configuration = null;

		internal DefaultExpressionReader(DefaultExpressionConfiguration configuration, IScope scope, IExpressionConfigurationVisitor visitor) 
			: base(scope, visitor) {

			_configuration = configuration;
			ReadConfiguration(configuration);	
		}
		
		partial void ReadConfiguration(DefaultExpressionConfiguration configuration);
		
		protected override ExpressionType AstNodeType {
            get { return ExpressionType.Default; }
        }
	}
	
	public partial class InvokeExpressionReader : AbstractExpression
	{	
		private InvokeExpressionConfiguration _configuration = null;

		internal InvokeExpressionReader(InvokeExpressionConfiguration configuration, IScope scope, IExpressionConfigurationVisitor visitor) 
			: base(scope, visitor) {

			_configuration = configuration;
			ReadConfiguration(configuration);	
		}
		
		partial void ReadConfiguration(InvokeExpressionConfiguration configuration);
		
		protected override ExpressionType AstNodeType {
            get { return ExpressionType.Invoke; }
        }
	}
}
