namespace BookCatalog
{
    public interface IRepository
    {
        void Save(Catalog catalog, string path);
        Catalog Load(string path);
    }
}
