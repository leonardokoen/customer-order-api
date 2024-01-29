using CustomerOrder.Application.Common.Interfaces.GenericRepository;
using CustomerOrder.Domain.Entities;

namespace CustomerOrder.Application.Common.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {

    }
}
