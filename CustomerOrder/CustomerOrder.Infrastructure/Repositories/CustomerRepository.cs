using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Domain.Entities;
using CustomerOrder.Infrastructure.Common;

namespace CustomerOrder.Infrastructure.CustomerInfrastructure
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public Customer? GetCustomerByEmail(string email)
        {
            return _entities.FirstOrDefault(e => ((dynamic)e).Email == email);
        }
    }
}
