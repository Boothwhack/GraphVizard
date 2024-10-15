using SharpGraph;

var graph = new Graph("Test");
var u = graph.GetNode("U");
var v = graph.GetNode("V");
u.AddEdgeTo(v, "edge");

graph.Layout("dot");
graph.RenderToFile("png", "graph.png");
