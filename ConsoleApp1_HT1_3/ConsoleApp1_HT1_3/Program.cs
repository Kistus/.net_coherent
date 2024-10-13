using System.Diagnostics.CodeAnalysis;

namespace ConsoleAppHW1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of elements in the array: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            Console.WriteLine("Enter the elements of the array:");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Original array:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            int[] uniqueArray = new int[n];  // Maximum size could be n
            int uniqueCount = 0;

            for (int i = 0; i < n; i++)
            {
                bool isUnique = true;

                for (int j = 0; j < uniqueCount; j++)
                {
                    if (array[i] == uniqueArray[j])
                    {
                        isUnique = false;
                        break;
                    }
                }

                if (isUnique)
                {
                    uniqueArray[uniqueCount] = array[i];
                    uniqueCount++;
                }
            }

            Console.WriteLine("Array with unique elements:");
            for (int i = 0; i < uniqueCount; i++)
            {
                Console.Write(uniqueArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}