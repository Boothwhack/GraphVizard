namespace GraphVizard.Tests;

public class EdgeEnds
{
    [Fact]
    public void EdgeHeadTail()
    {
        var graph = RootGraph.Directed("Root Graph");

        var a = graph.GetNode("a");
        var b = graph.GetNode("b");

        var edge = a.AddEdgeTo(b);
        
        Assert.Equal(a, edge.Tail);
        Assert.Equal(b, edge.Head);
    }
}