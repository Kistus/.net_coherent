using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{   

public class DiagonalMatrix
{
    private int[] diagonalElements;

    public int Size { get; }

    public DiagonalMatrix(params int[] elements)
    {
        if (elements == null)
        {
            Size = 0;
            diagonalElements = new int[0];
        }
        else
        {
            Size = elements.Length;
            diagonalElements = new int[Size];
            Array.Copy(elements, diagonalElements, Size);
        }
    }

    private bool IsValidIndex(int i, int j)
    {
        return i >= 0 && j >= 0 && i < Size && j < Size;
    }

    public int this[int i, int j]
    {
        get
        {
            if (!IsValidIndex(i, j)) return 0;
            return i == j ? diagonalElements[i] : 0;
        }
        set
        {
            if (IsValidIndex(i, j) && i == j)
            {
                diagonalElements[i] = value;
            }
        }
    }


    public int Track()
    {
        int sum = 0;
        for (int i = 0; i < Size; i++)
        {
            sum += diagonalElements[i];
        }
        return sum;
    }

    public override bool Equals(object obj)
    {
        if (obj is DiagonalMatrix other && other.Size == Size)
        {
            for (int i = 0; i < Size; i++)
            {
                if (other.diagonalElements[i] != diagonalElements[i]) return false;
            }
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return string.Join(", ", diagonalElements);
    }

    public static DiagonalMatrix operator +(DiagonalMatrix m1, DiagonalMatrix m2)
    {
        int maxSize = Math.Max(m1.Size, m2.Size);
        int[] resultElements = new int[maxSize];

        for (int i = 0; i < maxSize; i++)
        {
            resultElements[i] = (i < m1.Size ? m1.diagonalElements[i] : 0) + (i < m2.Size ? m2.diagonalElements[i] : 0);
        }

        return new DiagonalMatrix(resultElements);
    }
}
}