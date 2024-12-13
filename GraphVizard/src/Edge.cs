using GraphVizard.Interop;

namespace GraphVizard;

public class Edge(Graph graph, SWIGTYPE_p_Agedge_t handle) : IEquatable<Edge>
{
    public readonly Graph Graph = graph;
    public readonly SWIGTYPE_p_Agedge_t Handle = handle;
    public readonly EdgeAttributes Attributes = new(handle);

    public static Edge? FromHandle(Graph graph, SWIGTYPE_p_Agedge_t? handle) =>
        handle is null ? null : new Edge(graph, handle);

    public Node Head => new(Graph, gv.headof(Handle));

    public Node Tail => new(Graph, gv.tailof(Handle));

    public bool Equals(Edge? other)
    {
        return other != null && Handle.Equals(other.Handle);
    }

    public override bool Equals(object? obj)
    {
        return obj is Edge other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Handle.GetHashCode();
    }

    public override string ToString()
    {
        return $"Edge('{Tail.Name}' -> '{Head.Name}')";
    }
}