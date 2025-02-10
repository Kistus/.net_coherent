

namespace LibrarySystem.Models
{
    public abstract class Book
    {
        public string Title { get; set; }
        public List<Author> Authors { get; set; }

        // Ensure this constructor exists
        protected Book(string title, List<Author> authors)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty", nameof(title));

            Title = title;
            Authors = authors ?? new List<Author>();
        }
    }
}
