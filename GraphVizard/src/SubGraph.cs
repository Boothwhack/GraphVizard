using GraphVizard.Interop;

namespace GraphVizard;

public sealed class SubGraph(Graph parent, SWIGTYPE_p_Agraph_t handle) : Graph(handle)
{
    internal readonly Graph Parent = parent;
}