using CustomerOrder.Application.Common.Interfaces;
using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Domain.Entities;
using MediatR;


namespace CustomerOrder.Application.Services.CustomerServices.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResult>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            if (_unitOfWork.Customer.GetCustomerByEmail(command.PreviousEmail) == null)
            {
                throw new Exception("User does not exist.");
            }

            if (command.Email != command.PreviousEmail && (_unitOfWork.Customer.GetCustomerByEmail(command.Email) != null))
            {
                throw new Exception("Cannot Update Email Because Already Exists.");
            }

            var customer = (_unitOfWork.Customer.GetCustomerByEmail(command.PreviousEmail));

            var updatedCustomer = new Customer
            {
                Name = command.FirstName + " " + command.LastName,
                Email = command.Email,
                Password = command.Password,
                Address = command.Address,
                PostalCode = command.PostalCode
            };
            _unitOfWork.Customer.Update(updatedCustomer, customer.Id);
            return new UpdateCustomerResult("Customer has been successfully updated.", command.PreviousEmail);
        }
    }
}
