namespace NJection.ExpressionSerialization.Ast
{
    public interface IScopeChild
    {
        IScope ParentScope { get; }
        IMethodScope RootScope { get; }
    }
}