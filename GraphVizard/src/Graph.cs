using System.Runtime.InteropServices;
using GraphVizard.Interop;

namespace GraphVizard;

public abstract class Graph(SWIGTYPE_p_Agraph_t handle) : IEquatable<Graph>, ICGraphCollection<Node>
{
    public SWIGTYPE_p_Agraph_t Handle { get; } = handle;
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

    Node? ICGraphCollection<Node>.First
    {
        get
        {
            lock (Sync.ContextLock)
                return Node.FromHandle(this, gv.firstnode(Handle));
        }
    }

    Node? ICGraphCollection<Node>.Next(Node current)
    {
        lock (Sync.ContextLock)
            return Node.FromHandle(this, gv.nextnode(Handle, current.Handle));
    }
    
    public IEnumerable<Node> Nodes => new CGraphCollectionEnumerable<Node>(this);

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

    public bool Equals(Graph? other)
    {
        return other != null && Handle.Equals(other.Handle);
    }

    public override bool Equals(object? obj)
    {
        return obj is Graph other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Handle.GetHashCode();
    }
}