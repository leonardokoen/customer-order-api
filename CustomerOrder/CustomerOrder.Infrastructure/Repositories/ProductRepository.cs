using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Domain.Entities;
using CustomerOrder.Infrastructure.Common;

namespace CustomerOrder.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CustomerOrderDbContext dbContext) : base(dbContext) {}

        public Product? GetProductByName(string productName)
        {
           return _dbContext.Set<Product>().FirstOrDefault(e => e.Name == productName);
        }
    }
}
