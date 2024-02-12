using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Application.Services.OrderServices.Common;
using CustomerOrder.Domain.Entities;
using MediatR;


namespace CustomerOrder.Application.Services.OrderServices.Queries.GetCustomerOrderHistory
{
    public class GetCustomerHistoryQueryHandler : IRequestHandler<GetCustomersOrderHistoryQuiry, GetCustomerOrderHistoryResult>
    {

        private readonly IUnitOfWork _unitOfWork;
        public GetCustomerHistoryQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<GetCustomerOrderHistoryResult> Handle(GetCustomersOrderHistoryQuiry request, CancellationToken cancellationToken)
        {
            var customer = _unitOfWork.Customer.GetCustomerById(request.CustomerId);
            var orders = _unitOfWork.Order.GetAll();
            var filteredOrders = orders
                .Where(order => order.CustomerId == customer.Id)
                .OrderBy(order => order.OrderDate).ToList();


            List<OrderResult> orderResults = new List<OrderResult>();
            foreach (var order in filteredOrders)
            {

                List<string> productNames = new List<string>();
                List<float> price = new List<float>();
                List<int> quantity = new List<int>();

                List<Item> items = _unitOfWork.Item.GetItemsByOrderId(order.Id);
                foreach (var item in items)
                {
                    var product = _unitOfWork.Item.GetProductByItemId(item.Id);
                    productNames.Add(product.Name);
                    price.Add(product.Price);
                    quantity.Add(item.Quantity);
                }
                var orderResult = new OrderResult
                {
                    ProductNames = productNames,
                    ItemQuantity = quantity,
                    ItemCost = price,
                    TotalCost = order.TotalCost,
                    OrderDate = order.OrderDate
                };
                orderResults.Add(orderResult);
            }

            return new GetCustomerOrderHistoryResult("Retrieved Customer Order History Succesfully.",orderResults); 
        }
    }
}
