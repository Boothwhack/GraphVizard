using SharpGraph;

var graph = new RootGraph("Test");
var u = graph.GetNode("U");
u.Attributes["style"] = "rounded";
u.Attributes["shape"] = "box";
var sub1 = graph.GetSubGraph("cluster_Sub1");
var sub2 = graph.GetSubGraph("cluster_Sub2");
sub1.Attributes["label"] = "Cluster 1";
var v = sub1.GetNode("V");
var edge = u.AddEdgeTo(v, "edge");
edge.Attributes["label"] = "Arrow";
var w = sub2.GetNode("W");
u.AddEdgeTo(w, "edge");

graph.Layout("dot");
graph.RenderToFile("png", "graph.png");
