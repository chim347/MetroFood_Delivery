using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Products.Commands.CreateProducts;
using MetroDelivery.Application.Features.Products.Commands.DeleteProducts;
using MetroDelivery.Application.Features.Products.Commands.UpdateProducts;
using MetroDelivery.Application.Features.Products.Queries;
using MetroDelivery.Application.Features.Products.Queries.GetAllProduct;
using MetroDelivery.Application.Features.Products.Queries.GetProductById;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Products
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]   
        public async Task<List<ProductResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetListProductQuery());
            return response;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ProductResponse> Get(string id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery
            {
                Id = id
            });
            return response;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> Create([FromBody] CreateProductCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
       /* [Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> Update(UpdateProductCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> Delete([FromQuery] DeleteProductCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
