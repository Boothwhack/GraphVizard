using System.Collections;
using GraphVizard.Interop;

namespace GraphVizard;

public class NodeEnumerable(Graph g) : IEnumerable<Node>
{
    public IEnumerator<Node> GetEnumerator() => new NodeEnumerator(g);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class NodeEnumerator(Graph g) : IEnumerator<Node>
    {
        private SWIGTYPE_p_Agnode_t? _n;
        
        public bool MoveNext()
        {
            _n = _n is null ? gv.firstnode(g.Handle) : gv.nextnode(g.Handle, _n);
            return _n is not null;
        }

        public void Reset()
        {
            _n = null;
        }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public Node Current => new(g, _n!);
    }
}
