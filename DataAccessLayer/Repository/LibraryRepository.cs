using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class LibraryRepository : IEntityRepository<Library>
    {
        public static List<Library> GetAll()
        {
            return Library._allLibraries;
        }
        public static Library Get(int id)
        {
            foreach (Library library in Library._allLibraries)
            {
                if (library.Id == id)
                {
                    return library;
                }
            }
            throw new Exception("Library not found");
        }
    }
}

