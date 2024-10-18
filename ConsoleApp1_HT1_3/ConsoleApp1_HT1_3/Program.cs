using System;

namespace ConsoleAppHW1_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements in the array:");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            Console.WriteLine("Enter the elements of the array:");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Original Array:");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            // Create new array with unique elements
            int[] uniqueArray = RemoveDuplicates(array);

            Console.WriteLine("Array with unique elements:");
            foreach (int element in uniqueArray)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        static int[] RemoveDuplicates(int[] array)
        {
            int[] tempArray = new int[array.Length];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < index; j++)
                {
                    if (array[i] == tempArray[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    tempArray[index] = array[i];
                    index++;
                }
            }

            int[] result = new int[index];
            Array.Copy(tempArray, result, index);

            return result;
        }
    }
}
