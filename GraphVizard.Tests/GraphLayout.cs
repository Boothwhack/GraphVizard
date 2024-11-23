namespace GraphVizard.Tests;

public class GraphLayout
{
    [Fact]
    public void BasicDirectedDotLayout()
    {
        var graph = RootGraph.Directed("Simple Graph");

        var a = graph.GetNode("a");
        var b = graph.GetNode("b");

        a.AddEdgeTo(b);
        
        graph.Layout("dot");
        var dot = graph.RenderToString("dot");

        Assert.Contains("graph \"Simple Graph\"", dot);
        Assert.Contains("a -> b", dot);
    }
}
