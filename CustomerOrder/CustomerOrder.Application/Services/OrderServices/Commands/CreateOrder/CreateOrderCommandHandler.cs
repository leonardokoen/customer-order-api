using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Application.Services.OrderServices.Common;
using CustomerOrder.Domain.Entities;
using MediatR;
using System.Xml.Linq;


namespace CustomerOrder.Application.Services.OrderServices.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {

        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private List<string> GetProductNamesFromRequest(List<(string, int)> itemInfo)
        {
            List<string> productNames = new List<string>();
            foreach (var item in itemInfo)
            {
                productNames.Add(item.Item1); // Adding the string part of the tuple to the list
            }

            return productNames;
        }

        private List<int> GetProductQuantityFromRequest(List<(string, int)> itemInfo)
        {
            List<int> productQuantity = new List<int>();
            foreach (var item in itemInfo)
            {
                productQuantity.Add(item.Item2); // Adding the string part of the tuple to the list
            }

            return productQuantity;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {

            List<string> productNames = command.ProductNames;
            List<int> productQuantity = command.ItemQuantity;
            List<Product> products = new List<Product>();
            Product? product = null;

            Customer? customer = _unitOfWork.Customer.GetCustomerByEmail(command.Email);
            if (customer == null)
            {
                throw new Exception("Customer does not exist");
            }

            foreach (var value in productQuantity)
            {
                if (value <= 0) {
                    throw new Exception("False quantity");
                }
        
            }

            foreach (var name in productNames)
            {
                product = _unitOfWork.Product.GetProductByName(name);
                if (product == null) 
                {
                    throw new Exception("Product with name, " + name + ".Does not exist");
                }
                products.Add(product);
            }

            var newOrderId = Guid.NewGuid();
            float totalPrice = 0.0f;
            List<Guid> itemsInOrderIds = new List<Guid>();
            for (int i = 0; i < products.Count; i++)
            {
                itemsInOrderIds.Add(Guid.NewGuid());
                var item = new Item
                {
                    Id = itemsInOrderIds[i],
                    Product = products[i],
                    Quantity = productQuantity[i],
                    OrderId = newOrderId
                };
                _unitOfWork.Item.Add(item);

                totalPrice += productQuantity[i] * products[i].Price;
            }

            DateTime dateTime = DateTime.Now;
            var order = new Order
            {
                Id = newOrderId,
                CustomerId = customer.Id,
                ItemIds = itemsInOrderIds,
                Quantity = productQuantity,
                TotalCost = totalPrice,
                OrderDate = dateTime
            };
            _unitOfWork.Order.Add(order);


            List<float> prices = products.Select(product => product.Price).ToList();
            return new CreateOrderResult("Successfully created Order", command.ProductNames, command.ItemQuantity, prices, dateTime, totalPrice);
        }
    }
}
