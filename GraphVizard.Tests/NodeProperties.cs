namespace GraphVizard.Tests;

public class NodeProperties
{
    [Fact]
    public void NodePositionProperty()
    {
        var graph = RootGraph.Directed("Simple Graph");

        var a = graph.GetNode("a");
        var b = graph.GetNode("b");
        var c = graph.GetNode("c");

        a.AddEdgeTo(b);
        a.AddEdgeTo(c);
        
        graph.Layout("dot");
        
        /*
         * Should produce graph roughly:
         *    |---|
         *    | a |
         *    |---|
         *    /   \
         * |---| |---|
         * | b | | c |
         * |---| |---|
         */
        
        Assert.True(b.Position.X < a.Position.X);
        Assert.True(a.Position.X < c.Position.X);
        Assert.True(b.Position.X < c.Position.X);

        Assert.Equal(b.Position.Y, c.Position.Y);
        Assert.True(b.Position.Y < a.Position.Y);
        Assert.True(c.Position.Y < a.Position.Y);
    }

    [Fact]
    public void NodeNameProperty()
    {
        var graph = RootGraph.Directed("Simple Graph");

        var a = graph.GetNode("a");
        var b = graph.GetNode("b");

        a.AddEdgeTo(b);
        
        Assert.Equal("a", a.Name);
        Assert.Equal("b", b.Name);
    }
}