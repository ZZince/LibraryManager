using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class AuthorRepository : IEntityRepository<Author>
    {
        public static List<Author> GetAll()
        {
            return Author._allAuthors;
        }

        public static Author Get(int id)
        {
            foreach (Author author in Author._allAuthors)
            {
                if (author.Id == id)
                {
                    return author;
                }
            }

            throw new Exception("Author not found");
        }
    }
}
