using System.Collections;

namespace GraphVizard;

internal class CGraphCollectionEnumerable<T>(ICGraphCollection<T> source) : IEnumerable<T> where T : class
{
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(source);
    }

    private class Enumerator(ICGraphCollection<T> source) : IEnumerator<T>
    {
        private T? _current;

        public bool MoveNext()
        {
            _current = _current is null ? source.First : source.Next(_current);
            return _current is not null;
        }

        public void Reset()
        {
            _current = null;
        }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public T Current => _current!;
    }
}