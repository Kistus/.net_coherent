using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;

using JsonFormatting = Newtonsoft.Json.Formatting;


namespace BookCatalog
{
    public class JSONRepository : IRepository
    {
        public void Save(Catalog catalog, string path)
        {
            foreach (var author in catalog.GetAllBooks().SelectMany(b => b.Authors).Distinct())
            {
                var booksByAuthor = catalog.GetAllBooks().Where(b => b.Authors.Contains(author)).ToList();
                File.WriteAllText(Path.Combine(path, $"{author.FirstName}_{author.LastName}.json"),
                    JsonConvert.SerializeObject(booksByAuthor, JsonFormatting.Indented));
            }
        }

        public Catalog Load(string path)
        {
            Catalog catalog = new Catalog();
            foreach (var file in Directory.GetFiles(path, "*.json"))
            {
                var books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(file));
                foreach (var book in books) catalog.AddBook(book);
            }
            return catalog;
        }
    }
}
