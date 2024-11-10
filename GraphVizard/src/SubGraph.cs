using GraphVizard.Interop;

namespace GraphVizard;

public sealed class SubGraph : Graph
{
    internal readonly Graph Parent;

    //public sealed override AttributeSet AttributeSet => Parent.AttributeSet;
    public override AttributeSet AttributeSet { get; }
    public override Attributes Attributes { get; }

    internal SubGraph(Graph parent, IntPtr ptr) : base(ptr)
    {
        Parent = parent;
        AttributeSet = new AttributeSet(Ptr);
        Attributes = new Attributes(AttributeSet, Ptr, CGraph.AGRAPH);
    }

    internal SubGraph(Graph parent, string name) : this(parent, CGraph.agsubg(parent.Ptr, name, true))
    {
    }
}