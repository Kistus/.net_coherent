using LibrarySystem.Models;

namespace LibrarySystem.Factory
{
    public class PaperLibraryFactory : ILibraryFactory
    {
        public Library<PaperBook> CreatePaperLibrary()
        {
            return new Library<PaperBook>();
        }

        public Library<EBook> CreateEBookLibrary()
        {
            throw new NotImplementedException("This factory does not support eBooks");
        }
    }
}
