namespace GraphVizard;

internal interface ICGraphCollection<T>
{
    internal T? First { get; }

    internal T? Next(T current);
}
