using SharpGraph.Native;

namespace SharpGraph;

public abstract class Graph(IntPtr ptr)
{
    public IntPtr Ptr { get; protected set; } = ptr;

    public Node GetNode(string name) => new(this, name, create: true);

    public Node? FindNode(string name)
    {
        var ptr = CGraph.agnode(Ptr, name, create: false);
        return ptr == 0 ? null : new Node(this, ptr);
    }

    public SubGraph GetSubGraph(string name) => new(this, name, create: true);

    public SubGraph? FindSubGraph(string name)
    {
        var ptr = CGraph.agsubg(Ptr, name, false);
        return ptr == 0 ? null : new SubGraph(this, ptr);
    }
}