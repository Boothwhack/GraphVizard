namespace GraphVizard.Tests;

public class Attributes {
    [Fact]
    public void NodeLabelAttribute() {
        var graph = RootGraph.Directed("Root");
        var u = graph.GetNode("U");
        u.Attributes["label"] = "U";

        graph.Layout("dot");
        var output = graph.RenderToString("dot");
        Assert.Contains("label=U", output);
    }

    [Fact]
    public void RootGraphLabelAttribute() {
        var graph = RootGraph.Directed("Root");
        graph.Attributes["label"] = "Root Graph";

        graph.Layout("dot");
        var output = graph.RenderToString("dot");
        Assert.Contains("label=\"Root Graph\"", output);
    }

    [Fact]
    public void SubGraphLabelAttribute() {
        var graph = RootGraph.Directed("Root");
        var cluster = graph.GetSubGraph("cluster_Cluster");
        cluster.Attributes["label"] = "Cluster";

        graph.Layout("dot");
        var output = graph.RenderToString("dot");
        Assert.Contains("label=Cluster", output);
    }
}

