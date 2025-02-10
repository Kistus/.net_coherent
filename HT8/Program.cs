
using LibrarySystem.Factory;
using LibrarySystem.Models;

class Program
{
    static async Task Main()
    {
        ILibraryFactory factory = new EBookLibraryFactory();
        var eBookLibrary = factory.CreateEBookLibrary();

        eBookLibrary.AddBook("example-identifier", new EBook(
            "Sample E-Book",
            new List<Author> { new Author("John", "Doe", null) },
            "example-identifier",
            new List<string> { "PDF", "EPUB" }
        ));

        await eBookLibrary.InitializeEBookPagesAsync();

        foreach (var book in eBookLibrary.Catalog.Values)
        {
            if (book is EBook eBook)
            {
                Console.WriteLine($"Title: {eBook.Title}, Pages: {eBook.Pages}");
            }
        }
    }
}
