
using System.Text.RegularExpressions;

namespace BookCatalogLibrary
{
    public class Book
    {
        public string Title { get; }
        public DateTime? PublicationDate { get; }
        public HashSet<string> Authors { get; }
        public string Isbn { get; }

        public Book(string title, string isbn, DateTime? publicationDate = null, IEnumerable<string> authors = null)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));

            if (string.IsNullOrWhiteSpace(isbn) || !Regex.IsMatch(isbn, @"^\d{3}-\d-\d{2}-\d{6}-\d$|^\d{13}$"))
                throw new ArgumentException("Invalid ISBN format.", nameof(isbn));

            Title = title;
            Isbn = isbn;
            PublicationDate = publicationDate;
            Authors = authors != null ? new HashSet<string>(authors) : new HashSet<string>();
        }
    }

   
}
