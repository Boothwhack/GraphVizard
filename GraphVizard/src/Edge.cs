using GraphVizard.Interop;

namespace GraphVizard;

public class Edge(Graph graph, SWIGTYPE_p_Agedge_t handle)
{
    public readonly Graph Graph = graph;
    public readonly SWIGTYPE_p_Agedge_t Handle = handle;
    public readonly EdgeAttributes Attributes = new(handle);
}