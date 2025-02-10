using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookCatalog
{
    public class Book
    {
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public string ISBN { get; set; }

        public static bool IsValidISBN(string isbn)
        {
            return Regex.IsMatch(isbn, @"^\d{3}-\d-\d{2}-\d{6}-\d$") || Regex.IsMatch(isbn, @"^\d{13}$");
        }
    }
}
