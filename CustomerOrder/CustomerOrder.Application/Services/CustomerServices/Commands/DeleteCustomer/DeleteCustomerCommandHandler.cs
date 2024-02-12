using CustomerOrder.Application.Common.Interfaces;
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
            var customer = _unitOfWork.Customer.GetCustomerById(command.CustomerId) ?? throw new Exception("User does not exist.");
            _unitOfWork.Customer.Delete(customer.Id);
            await _unitOfWork.Commit();

            return new DeleteCustomerResult("Customer Deletion was Successful.");
        }
    }
}
