using CustomerOrder.Application.Services.OrderServices.Common;
using CustomerOrder.Application.Services.ProductServices.Commands;
using CustomerOrder.Application.Services.ProductServices.Common;
using CustomerOrder.Contracts.Products.Requests;
using CustomerOrder.Contracts.Products.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.Api.Controllers.ProductController
{
    [ApiController]
    [Route("api")]
    public class CreateProductController : Controller
    {

        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CreateProductController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var command = _mapper.Map<CreateProductCommand>(request);
            CreateProductResult createProductResult = await _mediator.Send(command);
            var response = _mapper.Map<CreateProductResponse>(createProductResult);
            return Ok(response);
        }
    }
}
