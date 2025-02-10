using System.Text.RegularExpressions;

namespace LibrarySystem.Models
{
    public class EBook : Book
    {
        public string ResourceIdentifier { get; set; }
        public List<string> Formats { get; set; }
        public int Pages { get; private set; }

        public EBook(string title, List<Author> authors, string resourceIdentifier, List<string> formats)
            : base(title, authors)
        {
            if (string.IsNullOrWhiteSpace(resourceIdentifier))
                throw new ArgumentException("Resource identifier cannot be null or empty");

            ResourceIdentifier = resourceIdentifier;
            Formats = formats ?? throw new ArgumentException("Formats list cannot be null");
        }

        public async Task InitializePagesAsync()
        {
            string url = $"https://archive.org/details/{ResourceIdentifier}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string htmlContent = await client.GetStringAsync(url);
                    Match match = Regex.Match(htmlContent, @"<span itemprop=""numberOfPages"">(\d+)</span>");
                    if (match.Success && int.TryParse(match.Groups[1].Value, out int pages))
                    {
                        Pages = pages;
                    }
                }
                catch (Exception)
                {
                    Pages = 0; // Default if unable to fetch pages
                }
            }
        }
    }
}
