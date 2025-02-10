using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class PaperBook : Book
    {
        public DateTime? PublicationDate { get; set; }
        public List<string> ISBNs { get; set; }
        public string Publisher { get; set; }

        public PaperBook(string title, List<Author> authors, DateTime? publicationDate, List<string> isbns, string publisher)
            : base(title, authors)
        {
            ISBNs = isbns ?? throw new ArgumentException("ISBNs list cannot be null");
            Publisher = publisher ?? throw new ArgumentException("Publisher cannot be null or empty");
            PublicationDate = publicationDate;
        }
    }
}
