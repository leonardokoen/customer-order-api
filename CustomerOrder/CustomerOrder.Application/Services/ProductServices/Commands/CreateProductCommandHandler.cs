using MediatR;
using CustomerOrder.Application.Services.ProductServices.Commands;
using CustomerOrder.Application.Services.ProductServices.Common;
using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Domain.Entities;

namespace ProductOrder.Application.Services.ProductServices.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {

        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            for (var i = 0; i < command.ProductNames.Count; i++)
            {
                var product = new Product
                {
                    Name = command.ProductNames[i],
                    Price = command.Prices[i]
                };
                _unitOfWork.Product.Add(product);
            }
            return new CreateProductResult("Product Creation was Succesful.");
        }
    }
}
