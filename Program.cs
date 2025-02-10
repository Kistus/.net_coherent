using System;
using LibrarySystem;
using LibrarySystem.Factory;
using LibrarySystem.Models;

class Program
{
    static void Main()
    {
        ILibraryFactory factory = new PaperLibraryFactory();
        var paperLibrary = factory.CreatePaperLibrary();

        Console.WriteLine("Library system initialized!");
    }
}
