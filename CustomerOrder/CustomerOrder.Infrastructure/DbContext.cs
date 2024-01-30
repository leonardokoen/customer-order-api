using CustomerOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CustomerOrder.Infrastructure
{
    public class CustomerOrderDbContext : DbContext
    {

        public CustomerOrderDbContext(DbContextOptions<CustomerOrderDbContext> options) : base(options) { }
        public DbSet<Item> Items { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;
    }
}
