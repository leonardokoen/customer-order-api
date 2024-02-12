
using CustomerOrder.Application.Common.Interfaces;

namespace CustomerOrder.Application.Services.ProductServices.Common
{
    public record CreateProductResult(
        string Message
    ) : IResult;
}
