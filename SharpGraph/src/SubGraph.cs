using SharpGraph.Native;

namespace SharpGraph;

public class SubGraph : Graph
{
    internal Graph Parent;

    internal SubGraph(Graph parent, IntPtr ptr) : base(ptr)
    {
        Parent = parent;
    }

    internal SubGraph(Graph parent, string name, bool create) : base(CGraph.agsubg(parent.Ptr, name, create))
    {
        Parent = parent;
    }
}