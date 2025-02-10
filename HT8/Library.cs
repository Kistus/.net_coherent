using LibrarySystem.Models;


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
            if (!string.IsNullOrWhiteSpace(key) && !Catalog.ContainsKey(key))
            {
                Catalog[key] = book;
            }
        }

        public async Task InitializeEBookPagesAsync()
        {
            foreach (var book in Catalog.Values)
            {
                if (book is EBook eBook)
                {
                    await eBook.InitializePagesAsync();
                }
            }
        }
    }
}
