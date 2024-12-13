using System.Collections;
using GraphVizard.Interop;

namespace GraphVizard;

public class EdgesInGraphEnumerable(RootGraph g) : IEnumerable<Edge>
{
    public IEnumerator<Edge> GetEnumerator() => new EdgeEnumerator(g);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class EdgeEnumerator(RootGraph g) : IEnumerator<Edge>
    {
        private SWIGTYPE_p_Agedge_t? _e;
        
        public bool MoveNext()
        {
            _e = _e is null ? gv.firstedge(g.Handle) : gv.nextedge(g.Handle, _e);
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

        public Edge Current => new(g, _e!);
    }
}