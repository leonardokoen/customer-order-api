using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Application.Common.Interfaces.Repositories;

namespace CustomerOrder.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(
            ICustomerRepository customerRepository,
            IItemRepository itemRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public IProductRepository Product
        {
            get { return _productRepository; }
        }
        public IOrderRepository Order
        {
            get { return _orderRepository; }
        }
        public IItemRepository Item
        {
            get { return _itemRepository; }
        }
        public ICustomerRepository Customer
        {
            get { return _customerRepository; }
        }

        public Task Commit()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {

        }
    }
}
