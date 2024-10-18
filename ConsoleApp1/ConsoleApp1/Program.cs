using System;

namespace ConsoleAppHW1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
            static string ConvertIntToDuodecimal(int intNumber)
        {
            // Handling the edge case where the number is zero.
            if (intNumber == 0) return "0";
        
            string result = string.Empty;
            const string digits = "0123456789AB";
        
            // Check if the number is negative
            bool isNegative = intNumber < 0;
        
            // Work with the absolute value of the number
            intNumber = Math.Abs(intNumber);
        
            while (intNumber > 0)
            {
                result = digits[intNumber % 12] + result;
                intNumber /= 12;
            }
        
            // If the original number was negative, prepend a minus sign
            if (isNegative)
            {
                result = "-" + result;
            }
        
            return result;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter two integers: ");

            // Parse user input directly
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            // Loop through the range [a, b]
            for (int i = a; i <= b; i++)
            {
                string duodecimal = ConvertIntToDuodecimal(i);

                // Count occurrences of 'A' in the duodecimal string
                int countA = 0;
                foreach (char c in duodecimal)
                {
                    if (c == 'A')
                    {
                        countA++;
                    }
                }

                // Print the number if it has exactly two 'A's in its duodecimal representation
                if (countA == 2)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
