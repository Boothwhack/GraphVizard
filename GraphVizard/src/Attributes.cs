using GraphVizard.Interop;

namespace GraphVizard;

public class Attributes(AttributeSet attributeSet, IntPtr n, int type)
{
    public string? this[string name]
    {
        get
        {
            var idx = attributeSet.FindAttribIndex(name, type);
            return idx == 0 ? null : CGraph.agxget(n, idx);
        }
        set
        {
            var idx = attributeSet.GetAttributeIndex(name, type);
            CGraph.agxset(n, idx, value);
        }
    }
}