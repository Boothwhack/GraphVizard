using SharpGraph;

var graph = new RootGraph("Test");
var u = graph.GetNode("U");
var sub = graph.GetSubGraph("cluster_Sub");
var v = sub.GetNode("V");
u.AddEdgeTo(v, "edge");

graph.Layout("dot");
graph.RenderToFile("png", "graph.png");
