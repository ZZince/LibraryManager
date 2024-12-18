using BusinessObjects.Entity;
using BusinessObjects.Enum;

namespace Services.Services
{
    public interface IBookRepositoryManager : IRepositoryManager<Book>
    {
        new List<Book> GetAll();
        List<Book> GetCatalog(TypeLivre type);
        new Book Find(int id);
    }
}
