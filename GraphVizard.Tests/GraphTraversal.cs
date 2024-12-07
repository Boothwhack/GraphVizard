namespace GraphVizard.Tests;

public class GraphTraversal
{
    [Fact]
    public void TraverseRootGraphNodes()
    {
        var graph = RootGraph.Directed("Root Graph");

        graph.GetNode("a");
        graph.GetNode("b");

        var nodes = graph.Nodes();
        var names = nodes.Select(n => n.Name).ToHashSet();
        var expectedNames = new HashSet<string> { "a", "b" };

        Assert.Equal(expectedNames, names);
    }

    [Fact]
    public void TraverseSubGraphNodes()
    {
        var graph = RootGraph.Directed("Root Graph");

        graph.GetNode("a");
        graph.GetNode("b");

        var subgraph = graph.GetSubGraph("Sub Graph");

        subgraph.GetNode("c");

        // enumerating root graph should produce all nodes in graph tree
        var rootNodes = graph.Nodes();
        var rootNames = rootNodes.Select(n => n.Name).ToHashSet();
        var expectedRootNames = new HashSet<string> { "a", "b", "c" };
        Assert.Equal(expectedRootNames, rootNames);

        // enumerating sub graph should only produce its nodes
        var subNodes = subgraph.Nodes();
        var subNames = subNodes.Select(n => n.Name).ToHashSet();
        var expectedSubNames = new HashSet<string> { "c" };
        Assert.Equal(expectedSubNames, subNames);
    }
}