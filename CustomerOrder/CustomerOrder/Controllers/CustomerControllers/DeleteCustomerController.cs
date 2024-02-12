using CustomerOrder.Application.Services.CustomerServices.Commands.DeleteCustomer;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Contracts.Customer.Requests;
using CustomerOrder.Contracts.Customer.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.Api.Controllers.Customer
{
    [ApiController]
    [Route("api")]

    public class DeleteCustomerController : Controller
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public DeleteCustomerController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(DeleteCustomerRequest request)
        {
            var command = _mapper.Map<DeleteCustomerCommand>(request);
            DeleteCustomerResult deleteCustomerResult = await _mediator.Send(command);
            var response = _mapper.Map<DeleteCustomerResponse>(deleteCustomerResult);
            return Ok(response);

        }
    }
}
