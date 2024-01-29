using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Domain.Entities;
using CustomerOrder.Infrastructure.Common;

namespace CustomerOrder.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
    }
}
