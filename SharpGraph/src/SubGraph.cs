using SharpGraph.Native;

namespace SharpGraph;

public class SubGraph : Graph
{
    internal readonly Graph Parent;
    public sealed override AttributeSet AttributeSet => Parent.AttributeSet;
    public override Attributes Attributes { get; }

    internal SubGraph(Graph parent, IntPtr ptr) : base(ptr)
    {
        Parent = parent;
        Attributes = new Attributes(AttributeSet, Ptr, CGraph.AGRAPH);
    }

    internal SubGraph(Graph parent, string name, bool create) : base(CGraph.agsubg(parent.Ptr, name, create))
    {
        Parent = parent;
        Attributes = new Attributes(AttributeSet, Ptr, CGraph.AGRAPH);
    }
}