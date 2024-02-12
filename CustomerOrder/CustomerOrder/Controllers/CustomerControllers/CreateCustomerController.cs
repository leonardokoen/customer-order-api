using CustomerOrder.Application.Services.CustomerServices.Commands.CreateCustomer;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Contracts.Customer;
using CustomerOrder.Contracts.Customer.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.Api.Controllers.Customer
{
    [ApiController]
    [Route("api")]
    public class CreateCustomerController : Controller
    {


        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public CreateCustomerController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {
            var command = _mapper.Map<CreateCustomerCommand>(request);
            CreateCustomerResult createCustomerResult = await _mediator.Send(command);
            var response = _mapper.Map<CreateCustomerResponse>(createCustomerResult);
            return Ok(response);
        }
    }
}
