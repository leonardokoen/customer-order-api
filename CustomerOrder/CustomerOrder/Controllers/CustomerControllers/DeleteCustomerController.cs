using CustomerOrder.Application.Services.CustomerServices;
using CustomerOrder.Application.Services.CustomerServices.Commands.CreateCustomer;
using CustomerOrder.Application.Services.CustomerServices.Commands.DeleteCustomer;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Contracts.Customer;
using CustomerOrder.Contracts.Customer.Requests;
using CustomerOrder.Contracts.Customer.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.Api.Controllers.Customer
{
    [ApiController]
    [Route("api")]

    public class DeleteCustomerController : Controller
    {
        private readonly ISender _mediator;

        public DeleteCustomerController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(DeleteCustomerRequest request)
        {
            var command = new DeleteCustomerCommand(request.Email, request.Password);
            DeleteCustomerResult deleteCustomerResult = await _mediator.Send(command);
            var response = new DeleteCustomerResponse(deleteCustomerResult.Message, deleteCustomerResult.Email);
            return Ok(response);

        }
    }
}
