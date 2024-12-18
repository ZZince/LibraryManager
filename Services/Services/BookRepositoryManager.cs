using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;

namespace Services.Services
{
    public class BookRepositoryManager : IBookRepositoryManager
    {
        public IGenericRepository<Book> Repository { get; set; }

        public BookRepositoryManager(IGenericRepository<Book> repository)
        {
            Repository = repository;
        }

        public List<Book> GetAll()
        {
            return Repository.GetAll();
        }

        public Book Find(int id)
        {
            return Repository.Get(id);
        }

        public List<Book> GetCatalog(TypeLivre type)
        {
            List<Book> books = Repository.GetAll();
            return books.Where(b => b.Type == type).ToList();
        }
    }
}
