using CustomerOrder.Contracts.Common;

namespace CustomerOrder.Contracts.Products.Responses
{
    public record CreateProductResponse(
        string Message
): IResponse;
}
