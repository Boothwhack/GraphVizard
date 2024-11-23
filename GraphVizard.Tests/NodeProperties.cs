namespace GraphVizard.Tests;

public class NodeProperties
{
    /*[Fact]
    public void NodePositionProperty()
    {
        var graph = RootGraph.Directed("Simple Graph");

        var a = graph.GetNode("a");
        var b = graph.GetNode("b");

        a.AddEdgeTo(b);
        
        graph.Layout("dot");
        
        /*
         * Should produce graph roughly:
         * |---|
         * | a |
         * |---|
         *   |
         * |---|
         * | b |
         * |---|
         */
        
        /*Assert.Equal(a.Position.X, b.Position.X);
        Assert.True(a.Position.Y > b.Position.Y);
    }*/

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