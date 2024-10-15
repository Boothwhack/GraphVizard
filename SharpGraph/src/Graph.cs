using SharpGraph.Native;
using static SharpGraph.Native.GraphViz;

namespace SharpGraph;

public class Graph : IDisposable
{
    internal IntPtr Ptr;

    public Graph(string label)
    {
        // TODO: Validate descriptor
        Ptr = CGraph.agopen(label, 0b01001000, 0);
    }

    public Node GetNode(string name) => new(this, name, create: true);

    public Node? FindNode(string name)
    {
        var ptr = CGraph.agnode(Ptr, name, create: false);
        return ptr == 0 ? null : new Node(this, ptr);
    }

    public void Dispose()
    {
        if (Ptr != 0)
        {
            CGraph.agclose(Ptr);
            Ptr = 0;
        }

        GC.SuppressFinalize(this);
    }

    public void Layout(string algo)
    {
        gvLayout(Context.GetContext(), Ptr, algo);
    }

    public void RenderToFile(string format, string path)
    {
        gvRenderFilename(Context.GetContext(), Ptr, format, path);
    }
}