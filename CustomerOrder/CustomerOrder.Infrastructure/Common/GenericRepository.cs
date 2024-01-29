using CustomerOrder.Application.Common.Interfaces.GenericRepository;

namespace CustomerOrder.Infrastructure.Common
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected static readonly List<T> _entities = new List<T>();

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _entities.FirstOrDefault(e => ((dynamic)e).Id == id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public void Update(T entity, Guid id)
        {
            var existingEntity = _entities.FirstOrDefault(e => ((dynamic)e).Id == id);
            if (existingEntity != null)
            {
                var index = _entities.IndexOf(existingEntity);
                _entities[index] = entity;
            }
        }
    }
}
