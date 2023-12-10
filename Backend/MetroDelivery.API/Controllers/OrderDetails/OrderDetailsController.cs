using MediatR;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Application.Features.OrderDetails.Queries;
using MetroDelivery.Application.Features.OrderDetails.Queries.GetAllOrderDetail;
using MetroDelivery.Application.Features.OrderDetails.Queries.GetByIdOrderDetail;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.OrderDetails
{
    [Route("api/v1/order-details")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IProductRepository productRepository, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<OrderDetailResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetListOrderDetailQuery());
            return response;
        }

        [HttpGet]
        [Route("{orderid}")]
        public async Task<List<OrderDetailResponse>> Get(string orderid)
        {
            var response = await _mediator.Send(new GetOrderDetailByIdQuery
            {
                OrderId = orderid
            });
            return response;
        }

        /*[HttpPost]
        [Route("create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create([FromQuery] CreateOrderDetailCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetAll), new { id = response });
        }*/
        
    }
}
