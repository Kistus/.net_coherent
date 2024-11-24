using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookCatalogLibrary
{
    public class Book
    {
        private const string IsbnPattern = @"^\d{3}-\d-\d{2}-\d{6}-\d$|^\d{13}$";

        public string Title { get; }
        public DateTime? PublicationDate { get; }
        public HashSet<string> Authors { get; }
        public string Isbn { get; }

        public Book(string title, string isbn, DateTime? publicationDate = null, IEnumerable<string> authors = null)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("No null/empty", nameof(title));

            if (string.IsNullOrWhiteSpace(isbn) || !Regex.IsMatch(isbn, IsbnPattern))
                throw new ArgumentException("error ISBN", nameof(isbn));

            Title = title;
            Isbn = NormalizeIsbn(isbn);
            PublicationDate = publicationDate;
            Authors = authors != null ? new HashSet<string>(authors) : new HashSet<string>();
        }

        private static string NormalizeIsbn(string isbn)
        {
            return isbn.Replace("-", "").Trim();
        }
    }
}
