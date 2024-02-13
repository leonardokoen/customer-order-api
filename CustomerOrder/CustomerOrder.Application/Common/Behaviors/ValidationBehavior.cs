using CustomerOrder.Application.Services.CustomerServices.Commands.CreateCustomer;
using CustomerOrder.Application.Services.CustomerServices.Common;
using MediatR;

namespace CustomerOrder.Application.Common.Behaviors
{
    public class ValidateCreateCustomerCommandBehavior :
        IPipelineBehavior<CreateCustomerCommand, CreateCustomerResult>
    {
        public async Task<CreateCustomerResult> Handle(CreateCustomerCommand request, RequestHandlerDelegate<CreateCustomerResult> next, CancellationToken cancellationToken)
        {
            var result = await next();
            return result;
        }
    }
}
