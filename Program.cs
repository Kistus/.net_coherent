using System;
using System.Collections.Generic;
using System.IO;

namespace BookCatalog
{
    class Program
    {
        static void Main()
        {
            Catalog catalog = new Catalog();

            Author author1 = new Author { FirstName = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903, 6, 25) };
            Author author2 = new Author { FirstName = "Aldous", LastName = "Huxley", DateOfBirth = new DateTime(1894, 7, 26) };

            Book book1 = new Book { Title = "1984", ISBN = "123-4-56-789012-3", PublicationDate = new DateTime(1949, 6, 8), Authors = new List<Author> { author1 } };
            Book book2 = new Book { Title = "Animal Farm", ISBN = "987-6-54-321098-7", PublicationDate = new DateTime(1945, 8, 17), Authors = new List<Author> { author1 } };
            Book book3 = new Book { Title = "Brave New World", ISBN = "111-2-33-444555-6", PublicationDate = new DateTime(1932, 1, 1), Authors = new List<Author> { author2 } };
            Book book4 = new Book { Title = "Island", ISBN = "222-3-44-555666-7", PublicationDate = new DateTime(1962, 1, 1), Authors = new List<Author> { author2 } };

            catalog.AddBook(book1);
            catalog.AddBook(book2);
            catalog.AddBook(book3);
            catalog.AddBook(book4);

            XMLRepository xmlRepo = new XMLRepository();
            string xmlPath = "catalog.xml";
            xmlRepo.Save(catalog, xmlPath);
            Catalog loadedFromXml = xmlRepo.Load(xmlPath);

            JSONRepository jsonRepo = new JSONRepository();
            string jsonPath = "./json_data";
            Directory.CreateDirectory(jsonPath);
            jsonRepo.Save(catalog, jsonPath);
            Catalog loadedFromJson = jsonRepo.Load(jsonPath);

            Console.WriteLine("Serialization and deserialization completed successfully.");
        }
    }
}
