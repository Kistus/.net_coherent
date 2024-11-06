public class DiagonalMatrix<T>
{
    private readonly T[] _elements;
    public int Size { get; }

    public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

    public DiagonalMatrix(int size)
    {
        if (size < 0) throw new ArgumentException("non-negative.");
        Size = size;
        _elements = new T[size];
    }

    public T this[int i, int j]
    {
        get
        {
            ValidateIndices(i, j);
            return i == j ? _elements[i] : default;
        }
        set
        {
            ValidateIndices(i, j);
            if (i == j && !Equals(_elements[i], value))
            {
                var oldValue = _elements[i];
                _elements[i] = value;
                ElementChanged?.Invoke(this, new ElementChangedEventArgs<T>(i, oldValue, value));
            }
        }
    }

    private void ValidateIndices(int i, int j)
    {
        if (i < 0 || i >= Size || j < 0 || j >= Size)
            throw new IndexOutOfRangeException("out of range.");
    }

    public static DiagonalMatrix<T> Add(DiagonalMatrix<T> matrix1, DiagonalMatrix<T> matrix2, Func<T, T, T> addFunction)
    {
        if (matrix1.Size != matrix2.Size) throw new ArgumentException("must be the same size.");
        var result = new DiagonalMatrix<T>(matrix1.Size);
        for (int i = 0; i < matrix1.Size; i++)
        {
            result[i, i] = addFunction(matrix1[i, i], matrix2[i, i]);
        }
        return result;
    }
}
