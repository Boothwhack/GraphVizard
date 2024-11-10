using GraphVizard.Interop;

namespace GraphVizard;

public class Edge
{
    private readonly IntPtr _ptr;
    public readonly Attributes Attributes;

    internal Edge(Graph graph, IntPtr ptr)
    {
        _ptr = ptr;
        Attributes = graph.AttributeSet.AttributesFor(_ptr, CGraph.AGEDGE);
    }

    internal Edge(Graph graph, IntPtr tail, IntPtr head, string? identifier) : this(graph,
        CGraph.agedge(graph.Ptr, tail, head, identifier, true))
    {
    }
}