using BusinessObjects.Entity;
using DataAccessLayer.Repository;

namespace Services.Services
{
    public class RepositoryManager<T> : IRepositoryManager<T> where T : IEntity
    {
        public IGenericRepository<T> Repository { get; set; }

        public RepositoryManager(IGenericRepository<T> repository)
        {
            Repository = repository;
        }

        public List<T> GetAll()
        {
            return Repository.GetAll();
        }

        public T Find(int id)
        {
            return Repository.Get(id);
        }
    }
}
