using SharpGraph.Native;

namespace SharpGraph;

public class Node
{
    internal Graph Graph;
    internal IntPtr Ptr;

    internal Node(Graph graph, IntPtr ptr)
    {
        Graph = graph;
        Ptr = ptr;
    }

    internal Node(Graph graph, string name, bool create)
    {
        Graph = graph;
        Ptr = CGraph.agnode(graph.Ptr, name, create);
    }

    public Position Position => CGraph.ND_coord(Ptr);

    public void AddEdgeTo(Node head, string? identifier = null)
    {
        CGraph.agedge(Graph.Ptr, Ptr, head.Ptr, identifier, true);
    }
}