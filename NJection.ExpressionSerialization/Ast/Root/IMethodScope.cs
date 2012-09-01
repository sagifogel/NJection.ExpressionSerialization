using NJection.ExpressionSerialization.Expressions;

namespace NJection.ExpressionSerialization
{
    public interface IMethodScope : IBranchingRegistry
    {
        IContext Context { get; }
        IBranchingRegistry BranchingRegistry { get; }
    }
}