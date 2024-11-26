using GraphVizard.Interop;

namespace GraphVizard;

public interface IAttributes
{
    public string? this[string name] { get; set; }
}

public class NodeAttributes(SWIGTYPE_p_Agnode_t n) : IAttributes
{
    public string? this[string name]
    {
        get
        {
            lock (Sync.ContextLock)
                return gv.getv(n, name);
        }
        set
        {
            lock (Sync.ContextLock)
                gv.setv(n, name, value);
        }
    }
}

public class EdgeAttributes(SWIGTYPE_p_Agedge_t e) : IAttributes
{
    public string? this[string name]
    {
        get
        {
            lock (Sync.ContextLock)
                return gv.getv(e, name);
        }
        set
        {
            lock (Sync.ContextLock)
                gv.setv(e, name, value);
        }
    }
}

public class GraphAttributes(SWIGTYPE_p_Agraph_t g) : IAttributes
{
    public string? this[string name]
    {
        get
        {
            lock (Sync.ContextLock)
                return gv.getv(g, name);
        }
        set
        {
            lock (Sync.ContextLock)
                gv.setv(g, name, value);
        }
    }
}