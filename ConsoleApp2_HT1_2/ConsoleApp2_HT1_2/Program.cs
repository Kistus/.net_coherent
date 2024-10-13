using System.Diagnostics.CodeAnalysis;

namespace ConsoleAppHW1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static string CalculateControlNumberIsbn(string isbn)
        {
            int sum = 0;

            for (int i = 0; i < isbn.Length; i++)
            {
                sum += int.Parse(isbn[i].ToString()) * (10 - i);
            }

            int controlNumber = (11 - (sum % 11)) % 11;
            string checkDigit = string.Empty;
            if (controlNumber == 10)
            {
                checkDigit = "X";
            }
            else
            {
                checkDigit = controlNumber.ToString();
            }

            return isbn + checkDigit;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter ISBN: ");
            string isbn = Console.ReadLine();
            string isbnWithControlNumber = CalculateControlNumberIsbn(isbn);
            Console.WriteLine("Control number: " + isbnWithControlNumber);
        }
    }
}