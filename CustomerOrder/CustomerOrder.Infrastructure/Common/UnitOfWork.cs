using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Application.Common.Interfaces.Repositories;

namespace CustomerOrder.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CustomerOrderDbContext _dbContext;

        private readonly ICustomerRepository _customerRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(
            CustomerOrderDbContext dbContext,
            ICustomerRepository customerRepository,
            IItemRepository itemRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _customerRepository = customerRepository;
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public IProductRepository Product => _productRepository;
        public IOrderRepository Order => _orderRepository;
        public IItemRepository Item => _itemRepository;
        public ICustomerRepository Customer => _customerRepository;

        public async Task Commit()
        {
            // This is where you persist all changes made to the DbContext to the database.
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            // Dispose the DbContext to free up resources.
            _dbContext.Dispose();
        }
    }
}
