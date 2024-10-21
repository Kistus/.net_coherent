using System;

namespace ConsoleAppHW1_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first 9 digits of the ISBN:");
            string isbn9 = Console.ReadLine();

            if (isbn9.Length != 9)
            {
                Console.WriteLine("Input must be 9 digits long.");
                return;
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = int.Parse(isbn9[i].ToString());
                sum += (10 - i) * digit;
            }

            int checkDigit = (11-sum % 11)%11
            string isbn10;

            if (checkDigit == 10)
            {
                isbn10 = isbn9 + "X";
            }
            else
            {
                isbn10 = isbn9 + checkDigit.ToString();
            }

            Console.WriteLine($"The complete ISBN is: {isbn10}");
        }
    }
}
