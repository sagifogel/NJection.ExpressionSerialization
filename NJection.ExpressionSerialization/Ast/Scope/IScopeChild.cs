using NJection.Core;
namespace NJection.Scope
{
    public interface IScopeChild
    {
        IScope ParentScope { get; }
        IMethodScope RootScope { get; }
    }
}