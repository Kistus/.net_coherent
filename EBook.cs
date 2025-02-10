using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class EBook : Book
    {
        public string ResourceIdentifier { get; set; }
        public List<string> Formats { get; set; }

        public EBook(string title, List<Author> authors, string resourceIdentifier, List<string> formats)
            : base(title, authors)
        {
            if (string.IsNullOrWhiteSpace(resourceIdentifier))
                throw new ArgumentException("Resource identifier cannot be null or empty");

            ResourceIdentifier = resourceIdentifier;
            Formats = formats ?? throw new ArgumentException("Formats list cannot be null");
        }
    }
}
