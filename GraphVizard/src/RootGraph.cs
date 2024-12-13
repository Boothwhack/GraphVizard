using System.Runtime.InteropServices;
using GraphVizard.Interop;

namespace GraphVizard;

public sealed class RootGraph(SWIGTYPE_p_Agraph_t g) : Graph(g), IDisposable, ICGraphCollection<Edge>
{
    ~RootGraph()
    {
        Dispose();
    }

    public static RootGraph Directed(string name)
    {
        lock (Sync.ContextLock)
            return new RootGraph(gv.digraph(name));
    }

    Edge? ICGraphCollection<Edge>.First
    {
        get
        {
            lock (Sync.ContextLock)
                return Edge.FromHandle(this, gv.firstedge(Handle));
        }
    }

    Edge? ICGraphCollection<Edge>.Next(Edge current)
    {
        lock (Sync.ContextLock)
            return Edge.FromHandle(this, gv.nextedge(Handle, current.Handle));
    }

    public IEnumerable<Edge> Edges => new CGraphCollectionEnumerable<Edge>(this);

    public void Dispose()
    {
        lock (Sync.ContextLock)
            gv.rm(Handle);
        GC.SuppressFinalize(this);
    }

    public void Layout(string algo)
    {
        lock (Sync.ContextLock)
            gv.layout(Handle, algo);
    }

    public void RenderToFile(string format, string path)
    {
        lock (Sync.ContextLock)
            gv.render(Handle, format, path);
    }

    public string RenderToString(string format)
    {
        lock (Sync.ContextLock)
            return gv.renderdata(Handle, format);
    }
}