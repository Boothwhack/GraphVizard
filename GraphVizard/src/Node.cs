using System.Runtime.InteropServices;
using GraphVizard.Interop;

namespace GraphVizard;

public class Node(Graph graph, SWIGTYPE_p_Agnode_t handle)
{
    public readonly Graph Graph = graph;
    public readonly SWIGTYPE_p_Agnode_t Handle = handle;
    public readonly NodeAttributes Attributes = new(handle);

    // public Position Position => CGraph.ND_coord(Handle); TODO

    public string Name => gv.nameof(Handle) ?? throw new IllegalStateException("Node ptr does not have a name");

    public Edge AddEdgeTo(Node head) => new(Graph, gv.edge(Handle, head.Handle));
}