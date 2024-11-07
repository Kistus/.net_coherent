using System.Collections;
public class SparseMatrix : IEnumerable<long>
{
    private readonly Dictionary<(int, int), long> _elements;
    public int Rows { get; }
    public int Columns { get; }

    public SparseMatrix(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
            throw new ArgumentException("<0");

        Rows = rows;
        Columns = columns;
        _elements = new Dictionary<(int, int), long>();
    }

    public long this[int row, int column]
    {
        get
        {
            ValidateIndices(row, column);
            return _elements.TryGetValue((row, column), out var value) ? value : 0;
        }
        set
        {
            ValidateIndices(row, column);
            if (value == 0)
                _elements.Remove((row, column));
            else
                _elements[(row, column)] = value;
        }
    }

    public override string ToString()
    {
        var result = string.Empty;
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                result += $"{this[i, j]} ";
            }
            result += Environment.NewLine;
        }
        return result.TrimEnd();
    }

    public IEnumerable<(int, int, long)> GetNonzeroElements()
    {
        foreach (var (key, value) in _elements)
        {
            yield return (key.Item1, key.Item2, value);
        }
    }

    public int GetCount(long value)
    {
        int count = 0;
        foreach (var element in this)
        {
            if (element == value)
                count++;
        }
        return count;
    }

    private void ValidateIndices(int row, int column)
    {
        if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            throw new IndexOutOfRangeException("out of range.");
    }

    public IEnumerator<long> GetEnumerator()
    {
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                yield return this[i, j];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

