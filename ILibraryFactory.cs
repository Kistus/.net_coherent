using LibrarySystem.Models;

namespace LibrarySystem.Factory
{
    public interface ILibraryFactory
    {
        Library<PaperBook> CreatePaperLibrary();
        Library<EBook> CreateEBookLibrary();
    }
}
