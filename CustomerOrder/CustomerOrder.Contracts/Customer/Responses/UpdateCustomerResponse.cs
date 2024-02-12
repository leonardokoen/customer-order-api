using CustomerOrder.Contracts.Common;

namespace CustomerOrder.Contracts.Customer.Responses
{
    public record UpdateCustomerResponse(
        string Message
     ) : IResponse;
}
