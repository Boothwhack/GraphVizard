using SharpGraph.Native;
using static SharpGraph.Native.GraphViz;

namespace SharpGraph;

public sealed class RootGraph : Graph, IDisposable
{
    // TODO: Validate descriptor

    public override AttributeSet AttributeSet { get; }
    public override Attributes Attributes { get; }

    public RootGraph(string label) : base(CGraph.agopen(label, 0b01001000, 0))
    {
        AttributeSet = new AttributeSet(Ptr);
        Attributes = new Attributes(AttributeSet, Ptr, CGraph.AGRAPH);
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