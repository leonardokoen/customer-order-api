using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Domain.Entities;
using CustomerOrder.Infrastructure.Common;

namespace CustomerOrder.Infrastructure.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public Item GetItemById(Guid id)
        {
            return _entities.FirstOrDefault(entity => entity.Id == id);
        }
    }
}
