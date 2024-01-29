using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Application.Services.CustomerServices.Common;
using MediatR;

namespace CustomerOrder.Application.Services.CustomerServices.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<DeleteCustomerResult> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = _unitOfWork.Customer.GetCustomerByEmail(command.Email) ?? throw new Exception("User does not exist.");
            if (customer.Password != command.Password)
            {
                throw new Exception("Wrong password try again.");
            }

            _unitOfWork.Customer.Delete(customer.Id);

            return new DeleteCustomerResult("Customer Deletion was Successful.", command.Email);
        }
    }
}
