using SharpGraph.Native;
using static SharpGraph.Native.GraphViz;

namespace SharpGraph;

public class RootGraph(string label) : Graph(CGraph.agopen(label, 0b01001000, 0)), IDisposable
{
    // TODO: Validate descriptor

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