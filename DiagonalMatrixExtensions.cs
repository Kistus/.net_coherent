

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
            return DiagonalMatrix.AddMatrices(m1, m2);
        }
    }

}
