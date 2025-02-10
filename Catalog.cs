using BookCatalogLibrary;

public class Catalog
{
    private readonly Dictionary<string, Book> _books;

    public Catalog()
    {
        _books = new Dictionary<string, Book>();
    }

    public void AddBook(Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book));

        string cleanedIsbn = CleanIsbn(book.Isbn);
        _books[cleanedIsbn] = book;
    }

    public Book GetBook(string isbn)
    {
        string cleanedIsbn = CleanIsbn(isbn);
        return _books.TryGetValue(cleanedIsbn, out var book) ? book : null;
    }

    public IEnumerable<string> GetBookTitles()
    {
        return _books.Values.Select(b => b.Title).OrderBy(title => title);
    }

    public IEnumerable<Book> GetBooksByAuthor(string author)
    {
        return _books.Values.Where(b => b.Authors.Contains(author))
                            .OrderBy(b => b.PublicationDate);
    }

    public IEnumerable<(string Author, int BookCount)> GetAuthorStatistics()
    {
        return _books.Values.SelectMany(b => b.Authors)
                            .GroupBy(author => author)
                            .Select(group => (Author: group.Key, BookCount: group.Count()));
    }

    private string CleanIsbn(string isbn)
    {
        return isbn.Replace("-", string.Empty);
    }
}