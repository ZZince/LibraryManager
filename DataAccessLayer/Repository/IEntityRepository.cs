using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public interface IEntityRepository<T> where T : IEntity
    {
        public abstract static List<T> GetAll();
        public abstract static T Get(int id);
    }
}
