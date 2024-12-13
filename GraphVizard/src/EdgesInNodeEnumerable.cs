using System.Collections;
using GraphVizard.Interop;

namespace GraphVizard;

public class EdgesInNodeEnumerable(Node n) : IEnumerable<Edge>
{
    public IEnumerator<Edge> GetEnumerator() => new EdgeEnumerator(n);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class EdgeEnumerator(Node n) : IEnumerator<Edge>
    {
        private SWIGTYPE_p_Agedge_t? _e;
        
        public bool MoveNext()
        {
            _e = _e is null ? gv.firstedge(n.Handle) : gv.nextedge(n.Handle, _e);
            return _e is not null;
        }

        public void Reset()
        {
            _e = null;
        }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public Edge Current => new(n.Graph, _e!);
    }
}