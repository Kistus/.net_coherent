using System.Collections.Generic;
using System.Linq;

namespace BookCatalog
{
    public class Catalog
    {
        private Dictionary<string, Book> books = new Dictionary<string, Book>();

        public void AddBook(Book book)
        {
            string normalizedISBN = book.ISBN.Replace("-", "");
            if (!books.ContainsKey(normalizedISBN))
            {
                books[normalizedISBN] = book;
                books[book.ISBN] = book;
            }
        }

        public Book GetBook(string isbn)
        {
            string normalizedISBN = isbn.Replace("-", "");
            return books.ContainsKey(normalizedISBN) ? books[normalizedISBN] : null;
        }

        public List<Book> GetAllBooks() => books.Values.Distinct().ToList();
    }
}
