using CustomerOrder.Application.Common.Interfaces;

namespace CustomerOrder.Application.Services.CustomerServices.Common
{
    public record CreateCustomerResult(
        string Message,
        Guid CustomerId
     ): IResult;

    public record DeleteCustomerResult(
        string Message
    ) : IResult;

    public record UpdateCustomerResult(
        string Message
    ) : IResult;
}
