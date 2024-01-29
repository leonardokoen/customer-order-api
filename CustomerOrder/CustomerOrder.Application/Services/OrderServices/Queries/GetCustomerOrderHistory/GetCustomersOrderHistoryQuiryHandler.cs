using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Application.Services.OrderServices.Common;
using MediatR;


namespace CustomerOrder.Application.Services.OrderServices.Queries.GetCustomerOrderHistory
{
    public class GetCustomerHistoryQueryHandler : IRequestHandler<GetCustomersOrderHistoryQuiry, GetCustomerOrderHistoryResult>
    {

        private readonly IUnitOfWork _unitOfWork;
        public GetCustomerHistoryQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<GetCustomerOrderHistoryResult> Handle(GetCustomersOrderHistoryQuiry request, CancellationToken cancellationToken)
        {
            var customer = _unitOfWork.Customer.GetCustomerByEmail(request.Email);
            var orders = _unitOfWork.Order.GetAll();
            var filteredOrders = orders
                .Where(order => order.CustomerId == customer.Id)
                .OrderBy(order => order.OrderDate).ToList();

            
            List<OrderResult> orderResults = new List<OrderResult>();
            foreach (var order in filteredOrders ) {
                List<string> productNames = new List<string>();
                List<float> price = new List<float>();
                foreach (var itemId in order.ItemIds) {
                    var item = _unitOfWork.Item.GetItemById(itemId);
                    productNames.Add(item.Product.Name);
                    price.Add(item.Product.Price);
                }
                var orderResult = new OrderResult
                {
                    ProductNames = productNames,
                    ItemQuantity = order.Quantity,
                    ItemCost = price,
                    TotalCost = order.TotalCost,
                    OrderDate = order.OrderDate
                };
                orderResults.Add(orderResult);
            }
            return new GetCustomerOrderHistoryResult(orderResults); 
        }
    }
}
