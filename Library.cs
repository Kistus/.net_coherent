using LibrarySystem.Models;
using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class Library<T> where T : Book
    {
        public Dictionary<string, T> Catalog { get; private set; }
        public List<string> PressReleaseItems { get; private set; }

        public Library()
        {
            Catalog = new Dictionary<string, T>();
            PressReleaseItems = new List<string>();
        }

        public void AddBook(string key, T book)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or empty");

            if (Catalog.ContainsKey(key))
                throw new InvalidOperationException("Duplicate key is not allowed");

            Catalog[key] = book;
        }
    }
}
