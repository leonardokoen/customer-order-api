using CustomerOrder.Application.Services.ProductServices.Common;
using MediatR;

namespace CustomerOrder.Application.Services.ProductServices.Commands
{ 
    public record CreateProductCommand(
        List<string> ProductNames,
        List<float> Prices
    ) : IRequest<CreateProductResult>;
}
