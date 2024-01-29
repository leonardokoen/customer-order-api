using CustomerOrder.Application.Common.Interfaces.GenericRepository;
using CustomerOrder.Domain.Entities;


namespace CustomerOrder.Application.Common.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer? GetCustomerByEmail(string email);
        IQueryable<Customer> GetAll();
    }
}
