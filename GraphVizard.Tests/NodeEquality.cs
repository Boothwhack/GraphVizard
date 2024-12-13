namespace GraphVizard.Tests;

public class NodeEquality
{
    [Fact]
    public void FindNodeEquality()
    {
        var graph = RootGraph.Directed("Root Graph");

        var a = graph.GetNode("a");
        var b = graph.GetNode("b");

        Assert.Equal(a, a);
        Assert.Equal(b, b);
        Assert.Equal(a, graph.FindNode("a"));
        Assert.Equal(b, graph.FindNode("b"));
        Assert.NotEqual(a, b);
        Assert.NotEqual(b, a);
        Assert.NotEqual(a, graph.FindNode("b"));
        Assert.NotEqual(b, graph.FindNode("a"));
    }
}