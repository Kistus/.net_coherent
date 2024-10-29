using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
public class Program2
{
    public static void Main()
    {
        DiagonalMatrix matrix1 = new DiagonalMatrix(1, 2, 3);
        DiagonalMatrix matrix2 = new DiagonalMatrix(4, 5);

        DiagonalMatrix sumMatrix = matrix1.Add(matrix2); // Using the Add extension method

        Console.WriteLine($"Sum Matrix: {sumMatrix}");
        Console.WriteLine($"Track: {sumMatrix.Track()}");
    }
}


}
