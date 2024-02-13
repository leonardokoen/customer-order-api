using CustomerOrder.Application.Services.OrderServices.Common;
using CustomerOrder.Application.Services.OrderServices.Queries.GetCustomerOrderHistory;
using CustomerOrder.Contracts.Orders.Requests;
using CustomerOrder.Contracts.Orders.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.Api.Controllers.ProductController
{
    [ApiController]
    [Route("api")]
    public class GetCustomerOrderHistoryController : Controller
    {

        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public GetCustomerOrderHistoryController(ISender mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("GetCustomerOrderHistory")]
        public async Task<IActionResult> GetCustomerOrderHistory (GetCustomerOrderHistoryRequest request)
        {
            var command = _mapper.Map<GetCustomersOrderHistoryQuiry>(request);
            GetCustomerOrderHistoryResult createProductResult = await _mediator.Send(command);
            List<OrderResponse> orderResponse = _mapper.Map<List<OrderResponse>>(createProductResult.OrderResults);
            var response = _mapper.Map<GetCustomersOrderHistoryResponse>((createProductResult, orderResponse));

            return Ok(response);
        }
    }
}
