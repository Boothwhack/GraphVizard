using System.Runtime.InteropServices;
using GraphVizard.Interop;

namespace GraphVizard;

public sealed class RootGraph(SWIGTYPE_p_Agraph_t g) : Graph(g), IDisposable
{
    ~RootGraph()
    {
        Dispose();
    }

    public override GraphAttributes Attributes { get; } = new(g);

    public static RootGraph Directed(string name) => new(gv.digraph(name));

    public void Dispose()
    {
        gv.rm(Handle);
        GC.SuppressFinalize(this);
    }

    public void Layout(string algo)
    {
        gv.layout(Handle, algo);
    }

    public void RenderToFile(string format, string path)
    {
        gv.render(Handle, format, path);
    }

    public string RenderToString(string format)
    {
        return gv.renderdata(Handle, format);
    }
}