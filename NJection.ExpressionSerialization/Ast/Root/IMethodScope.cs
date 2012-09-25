namespace NJection.ExpressionSerialization.Ast
{
    public interface IMethodScope : IBranchingRegistry
    {
        IContext Context { get; }
        IBranchingRegistry BranchingRegistry { get; }
    }
}