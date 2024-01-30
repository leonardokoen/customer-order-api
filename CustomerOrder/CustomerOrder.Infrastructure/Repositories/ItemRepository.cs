using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Domain.Entities;
using CustomerOrder.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrder.Infrastructure.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(CustomerOrderDbContext dbContext) : base(dbContext){}

        public Item GetItemById(Guid id)
        {
            return _dbContext.Set<Item>().FirstOrDefault(entity => entity.Id == id);
        }

        public List<Item> GetItemsByOrderId(Guid id)
        {
            return _dbContext.Set<Item>().Where(entity => entity.OrderId == id).ToList();
        }

        public Product? GetProductByItemId(Guid id)
        {
            var itemWithProduct = _dbContext.Set<Item>()
                                    .Include(i => i.Product) // Eager load the Product
                                    .SingleOrDefault(i => i.Id == id);
            return itemWithProduct?.Product;
        }
    }
}
