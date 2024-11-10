using GraphVizard.Interop;

namespace GraphVizard;

public class Node
{
    internal readonly Graph Graph;
    internal readonly IntPtr Ptr;
    public readonly Attributes Attributes;

    internal Node(Graph graph, IntPtr ptr)
    {
        Graph = graph;
        Ptr = ptr;
        Attributes = new Attributes(graph.AttributeSet, Ptr, CGraph.AGNODE);
    }

    internal Node(Graph graph, string name, bool create) : this(graph, CGraph.agnode(graph.Ptr, name, create))
    {
    }

    public Position Position => CGraph.ND_coord(Ptr);

    public string? Label
    {
        get => Attributes["label"];
        set => Attributes["label"] = value;
    }

    public Edge AddEdgeTo(Node head, string? identifier = null) => new(Graph, Ptr, head.Ptr, identifier);
}