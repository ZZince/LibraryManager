using BusinessObjects.Entity;
using BusinessObjects.Enum;

namespace DataAccessLayer.Repository
{
    public class BookRepository : IEntityRepository<Book>
    {
        public static List<Book> GetAll()
        {
            return Book._allBooks;
        }

        public static Book Get(int id)
        {
            foreach (Book book in Book._allBooks)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            throw new Exception("Book not found");
        }

        public static List<Book> GetByType(TypeLivre type)
        {
            List<Book> books = new List<Book>();
            foreach (Book book in Book._allBooks)
            {
                if (book.Type == type)
                {
                    books.Add(book);
                }
            }
            return books;
        }
    }
}