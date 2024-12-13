using System.Runtime.InteropServices;
using GraphVizard.Interop;

namespace GraphVizard;

public class Node(Graph graph, SWIGTYPE_p_Agnode_t handle) : IEquatable<Node>
{
    public readonly Graph Graph = graph;
    public readonly SWIGTYPE_p_Agnode_t Handle = handle;
    public readonly NodeAttributes Attributes = new(handle);

    public Position Position
    {
        get
        {
            lock (Sync.ContextLock)
                return Extensions.ND_coord(Handle);
        }
    }

    public string Name
    {
        get
        {
            string name;
            lock (Sync.ContextLock)
                name = gv.nameof(Handle);
            return name ?? throw new IllegalStateException("Node ptr does not have a name");
        }
    }

    public EdgesInNodeEnumerable Edges => new(this);

    public Edge AddEdgeTo(Node head)
    {
        SWIGTYPE_p_Agedge_t handle;
        lock (Sync.ContextLock)
            handle = gv.edge(Handle, head.Handle);
        return new Edge(Graph, handle);
    }

    public bool Equals(Node? other)
    {
        return other != null && Handle.Equals(other.Handle);
    }

    public override bool Equals(object? obj)
    {
        return obj is Node other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Handle.GetHashCode();
    }

    public override string ToString()
    {
        return $"Node('{Name}')";
    }
}