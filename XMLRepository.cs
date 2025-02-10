using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BookCatalog
{
    public class XMLRepository : IRepository
    {
        public void Save(Catalog catalog, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, catalog.GetAllBooks());
            }
        }

        public Catalog Load(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (TextReader reader = new StreamReader(path))
            {
                var books = (List<Book>)serializer.Deserialize(reader);
                Catalog catalog = new Catalog();
                foreach (var book in books) catalog.AddBook(book);
                return catalog;
            }
        }
    }
}
