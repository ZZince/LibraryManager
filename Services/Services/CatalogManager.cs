using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using BusinessObjects.Enum;
namespace Services.Services
{
    public class CatalogManager
    {
        public static List<Book> GetCatalog()
        {
            return BookRepository.GetAll();
        }

        public static List<Book> GetBooks(TypeLivre type)
        {
            return BookRepository.GetByType(type);
        }

        public static Book FindBook(int id)
        {
            return BookRepository.Get(id);
        }
    }
}
