using System.Runtime.InteropServices;
using GraphVizard.Interop;

namespace GraphVizard;

public abstract class Graph(SWIGTYPE_p_Agraph_t handle)
{
    public SWIGTYPE_p_Agraph_t Handle { get; protected set; } = handle;
    public abstract GraphAttributes Attributes { get; }
    public string Name => gv.nameof(Handle) ?? throw new IllegalStateException("Graph ptr does not have a name");

    public Node GetNode(string name) => new(this, gv.node(Handle, name));

    public Node? FindNode(string name)
    {
        var ptr = gv.findnode(Handle, name);
        return ptr == null ? null : new Node(this, ptr);
    }

    public SubGraph GetSubGraph(string name) => new(this, gv.graph(Handle, name));

    public SubGraph? FindSubGraph(string name)
    {
        var handle = gv.findsubg(Handle, name);
        return handle == null ? null : new SubGraph(this, handle);
    }
}