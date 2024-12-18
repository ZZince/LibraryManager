using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public interface IGenericRepository<T> where T : IEntity
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
    }
}
