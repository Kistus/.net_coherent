using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
 public static class DiagonalMatrixExtensions
{
    public static DiagonalMatrix Add(this DiagonalMatrix m1, DiagonalMatrix m2)
    {
        if (m1 == null || m2 == null)
        {
            throw new ArgumentNullException("Matrices cannot be null.");
        }

        int maxSize = Math.Max(m1.Size, m2.Size);
        int[] resultElements = new int[maxSize];

        for (int i = 0; i < maxSize; i++)
        {
            resultElements[i] = (i < m1.Size ? m1[i, i] : 0) + (i < m2.Size ? m2[i, i] : 0);
        }

        return new DiagonalMatrix(resultElements);
    }
}

}
