using CustomerOrder.Contracts.Common;

namespace CustomerOrder.Contracts.Customer.Responses
{
    public record CreateCustomerResponse(
        string Message,
        Guid CustomerId
     ) : IResponse;
}
