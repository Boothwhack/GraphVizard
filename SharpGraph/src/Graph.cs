using SharpGraph.Native;

namespace SharpGraph;

public abstract class Graph(IntPtr ptr)
{
    public IntPtr Ptr { get; protected set; } = ptr;
    public abstract AttributeSet AttributeSet { get; }
    public abstract Attributes Attributes { get; }

    public Node GetNode(string name) => new(this, name, create: true);

    public Node? FindNode(string name)
    {
        var ptr = CGraph.agnode(Ptr, name, create: false);
        return ptr == 0 ? null : new Node(this, ptr);
    }

    public SubGraph GetSubGraph(string name) => new(this, name);

    public SubGraph? FindSubGraph(string name)
    {
        var ptr = CGraph.agsubg(Ptr, name, false);
        return ptr == 0 ? null : new SubGraph(this, ptr);
    }
}