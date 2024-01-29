using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Domain.Entities;
using CustomerOrder.Infrastructure.Common;

namespace CustomerOrder.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public Product? GetProductByName(string productName)
        {
           return _entities.FirstOrDefault(e => ((dynamic)e).Name == productName);
        }
    }
}
