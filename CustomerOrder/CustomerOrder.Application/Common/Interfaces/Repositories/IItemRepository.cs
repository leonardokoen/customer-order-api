using CustomerOrder.Application.Common.Interfaces.GenericRepository;
using CustomerOrder.Domain.Entities;


namespace CustomerOrder.Application.Common.Interfaces.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        Item GetItemById(Guid id);
    }
}
