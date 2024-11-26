using System.Runtime.InteropServices;
using GraphVizard.Interop;

namespace GraphVizard;

public abstract class Graph(SWIGTYPE_p_Agraph_t handle)
{
    public SWIGTYPE_p_Agraph_t Handle { get; protected set; } = handle;
    public GraphAttributes Attributes { get; } = new(handle);

    public string Name
    {
        get
        {
            string name;
            lock (Sync.ContextLock)
                name = gv.nameof(Handle);
            return name ?? throw new IllegalStateException("Graph ptr does not have a name");
        }
    }

    public Node GetNode(string name)
    {
        SWIGTYPE_p_Agnode_t handle;
        lock (Sync.ContextLock)
            handle = gv.node(Handle, name);
        return new Node(this, handle);
    }

    public Node? FindNode(string name)
    {
        SWIGTYPE_p_Agnode_t ptr;
        lock (Sync.ContextLock)
            ptr = gv.findnode(Handle, name);
        return ptr == null ? null : new Node(this, ptr);
    }

    public SubGraph GetSubGraph(string name)
    {
        SWIGTYPE_p_Agraph_t handle;
        lock (Sync.ContextLock)
            handle = gv.graph(Handle, name);
        return new SubGraph(this, handle);
    }

    public SubGraph? FindSubGraph(string name)
    {
        SWIGTYPE_p_Agraph_t handle;
        lock (Sync.ContextLock)
            handle = gv.findsubg(Handle, name);
        return handle == null ? null : new SubGraph(this, handle);
    }
}