namespace NJection.ExpressionSerialization
{
    public interface IScopeChild
    {
        IScope ParentScope { get; }
        IMethodScope RootScope { get; }
    }
}