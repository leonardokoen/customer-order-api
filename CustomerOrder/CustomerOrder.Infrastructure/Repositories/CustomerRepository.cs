using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Domain.Entities;
using CustomerOrder.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrder.Infrastructure.CustomerInfrastructure
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerOrderDbContext dbContext) : base(dbContext){}

        public IQueryable<Customer> GetAll()
        {
            return _dbContext.Set<Customer>();
        }

        public Customer? GetCustomerById(Guid customerid) 
        {
            return _dbContext.Set<Customer>().FirstOrDefault(id => id.Id == customerid);
        }

        public Customer? GetCustomerByEmail(string email)
        {
            return _dbContext.Set<Customer>().FirstOrDefault(e => e.Email == email);
        }

        public Customer? GetCustomerByUsername(string username)
        {
            return _dbContext.Set<Customer>().FirstOrDefault(usrnm => usrnm.Username == username);
        }
    }
}
