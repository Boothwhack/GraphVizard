using System.Runtime.InteropServices;
using GraphVizard.Interop;

namespace GraphVizard;

public sealed class RootGraph(SWIGTYPE_p_Agraph_t g) : Graph(g), IDisposable
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