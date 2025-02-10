using LibrarySystem.Models;

namespace LibrarySystem.Factory
{
    public class EBookLibraryFactory : ILibraryFactory
    {
        public Library<EBook> CreateEBookLibrary()
        {
            return new Library<EBook>();
        }

        public Library<PaperBook> CreatePaperLibrary()
        {
            throw new NotImplementedException("This factory does not support paper books");
        }
    }
}
