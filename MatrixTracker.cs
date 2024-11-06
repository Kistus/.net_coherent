public class MatrixTracker<T>
{
    private readonly DiagonalMatrix<T> _matrix;
    private readonly Stack<(int, T)> _changeHistory = new();

    public MatrixTracker(DiagonalMatrix<T> matrix)
    {
        _matrix = matrix;
        _matrix.ElementChanged += OnElementChanged;
    }

    private void OnElementChanged(object sender, ElementChangedEventArgs<T> e)
    {
        _changeHistory.Push((e.Index, e.OldValue));
    }

    public void Undo()
    {
        if (_changeHistory.TryPop(out var lastChange))
        {
            _matrix[lastChange.Item1, lastChange.Item1] = lastChange.Item2;
        }
    }
}