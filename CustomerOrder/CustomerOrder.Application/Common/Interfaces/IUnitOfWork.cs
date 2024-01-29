using CustomerOrder.Application.Common.Interfaces.Repositories;


namespace CustomerOrder.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customer { get; }
        IOrderRepository Order { get; }
        IItemRepository Item { get; }
        IProductRepository Product { get; }
        Task Commit();
    }
}
