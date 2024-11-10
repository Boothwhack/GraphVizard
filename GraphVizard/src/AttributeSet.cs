using GraphVizard.Interop;

namespace GraphVizard;

public class AttributeSet(IntPtr g)
{
    private readonly Dictionary<string, IntPtr> _indices = [];

    public IntPtr GetAttributeIndex(string name, int type)
    {
        if (_indices.TryGetValue(name, out var value))
            return value;
        var idx = CGraph.agattr(g, type, name, "");
        _indices[name] = idx;
        return idx;
    }
    
    public IntPtr FindAttribIndex(string name, int type)
    {
        if (_indices.TryGetValue(name, out var value))
            return value;
        return CGraph.agattr(g, type, name, null);
    }

    public Attributes AttributesFor(IntPtr n, int type) => new(this, n, type);
}