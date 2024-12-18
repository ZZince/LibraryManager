using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        public List<T> AllObjects { get; set; } = new List<T>();

        public List<T> GetAll()
        {
            return AllObjects;
        }

        public T Get(int id)
        {
            foreach (T entity in AllObjects)
            {
                if (entity.Id == id)
                    return entity;
            }

            throw new Exception($"{typeof(T).Name} not found");
        }

        public void Add(T entity)
        {
            AllObjects.Add(entity);
        }
    }
}
