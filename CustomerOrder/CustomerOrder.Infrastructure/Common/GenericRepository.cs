using CustomerOrder.Application.Common.Interfaces.GenericRepository;
using CustomerOrder.Domain;
using Microsoft.EntityFrameworkCore;
namespace CustomerOrder.Infrastructure.Common
{
    public class GenericRepository<T> : IRepository<T> where T : class, IIdentifiable
    {
        public readonly CustomerOrderDbContext _dbContext;
        private DbSet<T> _entitySet;

        public GenericRepository(CustomerOrderDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _entitySet.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _dbContext.Remove(entity);
            }
        }

        public void Update(T entity, Guid id)
        {
            var existingEntity = _entitySet.FirstOrDefault(e => e.Id == id);
            if (existingEntity != null)
            {
                var entityEntry = _dbContext.Entry(existingEntity);

                foreach (var property in entityEntry.Metadata.GetProperties())
                {
                    if (property.IsKey()) // Skip the key property
                    {
                        continue;
                    }

                    var newValue = entity.GetType().GetProperty(property.Name)?.GetValue(entity);
                    if (newValue != null)
                    {
                        entityEntry.Property(property.Name).CurrentValue = newValue;
                    }
                }
            }
        }
    }
}
