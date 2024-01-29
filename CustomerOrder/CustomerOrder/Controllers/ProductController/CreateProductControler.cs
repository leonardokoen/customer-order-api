using CustomerOrder.Application.Services.OrderServices.Common;
using CustomerOrder.Application.Services.ProductServices.Commands;
using CustomerOrder.Application.Services.ProductServices.Common;
using CustomerOrder.Contracts.Products.Requests;
using CustomerOrder.Contracts.Products.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.Api.Controllers.ProductController
{
    [ApiController]
    [Route("api")]
    public class CreateProductController : Controller
    {

        private readonly ISender _mediator;

        public CreateProductController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var command = new CreateProductCommand(request.ProductNames, request.Prices);
            CreateProductResult createProductResult = await _mediator.Send(command);
            var response = new CreateProductResponse(createProductResult.message);
            return Ok(response);
        }
    }
}
