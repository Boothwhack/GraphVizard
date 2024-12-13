namespace GraphVizard.Tests;

public class GraphTraversal
{
    [Fact]
    public void TraverseRootGraphNodes()
    {
        var graph = RootGraph.Directed("Root Graph");

        graph.GetNode("a");
        graph.GetNode("b");

        var nodes = graph.Nodes;
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
        var rootNodes = graph.Nodes;
        var rootNames = rootNodes.Select(n => n.Name).ToHashSet();
        var expectedRootNames = new HashSet<string> { "a", "b", "c" };
        Assert.Equal(expectedRootNames, rootNames);

        // enumerating sub graph should only produce its nodes
        var subNodes = subgraph.Nodes;
        var subNames = subNodes.Select(n => n.Name).ToHashSet();
        var expectedSubNames = new HashSet<string> { "c" };
        Assert.Equal(expectedSubNames, subNames);
    }

    [Fact]
    public void TraverseNodeAllEdges()
    {
        var graph = RootGraph.Directed("Root Graph");
        var a = graph.GetNode("a");

        var b = graph.GetNode("b");
        var c = graph.GetNode("c");

        var d = graph.GetNode("d");

        a.AddEdgeTo(b);
        b.AddEdgeTo(a);

        a.AddEdgeTo(c);
        c.AddEdgeTo(d);
        d.AddEdgeTo(a);

        HashSet<(Node tail, Node head)> expectedAEdges =
        [
            (a, b),
            (b, a),
            (a, c),
            (d, a)
        ];
        Assert.Equal(expectedAEdges, a.Edges.Select(e => (e.Tail, e.Head)).ToHashSet());
    }

    [Fact]
    public void TraverseRootGraphEdges()
    {
        var graph = RootGraph.Directed("Root Graph");

        var a = graph.GetNode("a");
        var b = graph.GetNode("b");
        var c = graph.GetNode("c");
        var d = graph.GetNode("d");

        a.AddEdgeTo(b);
        b.AddEdgeTo(a);
        a.AddEdgeTo(c);
        c.AddEdgeTo(d);
        d.AddEdgeTo(a);

        HashSet<(Node tail, Node head)> expectedEdges =
        [
            (a, b),
            (b, a),
            (a, c),
            (c, d),
            (d, a)
        ];
        Assert.Equal(expectedEdges, graph.Edges.Select(e => (e.Tail, e.Head)).ToHashSet());
    }

    [Fact]
    public void TraverseSubGraphEdges()
    {
        var root = RootGraph.Directed("Root Graph");

        var sub1 = root.GetSubGraph("sub1");
        var sub2 = root.GetSubGraph("sub2");

        var a = sub1.GetNode("a");
        var b = sub1.GetNode("b");

        var c = sub2.GetNode("c");
        var d = sub2.GetNode("d");

        a.AddEdgeTo(b);
        b.AddEdgeTo(c);
        c.AddEdgeTo(d);
        
        HashSet<(Node tail, Node head)> expectedEdges =
        [
            (a, b),
            (b, c),
            (c, d)
        ];
        
        // Edges between nodes in sub-graphs should still appear in root graph
        Assert.Equal(expectedEdges, root.Edges.Select(e => (e.Tail, e.Head)).ToHashSet());
    }
}