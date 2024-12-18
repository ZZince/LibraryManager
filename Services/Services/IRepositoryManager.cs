using BusinessObjects.Entity;
using DataAccessLayer.Repository;

namespace Services.Services
{
    public interface IRepositoryManager<T> where T : IEntity
    {
        IGenericRepository<T> Repository { get; set; }
        List<T> GetAll();
        T Find(int id);
    }
}
