using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Application.Features.Orders.Commands.CreateOrder;
using MetroDelivery.Application.Features.Orders.Commands.UpdateOrder;
using MetroDelivery.Application.Features.Orders.Queries;
using MetroDelivery.Application.Features.Orders.Queries.GetAllOrder;
using MetroDelivery.Application.Features.Orders.Queries.GetByIdCustomer;
using MetroDelivery.Application.Features.Orders.Queries.GetOrderByManager;
using MetroDelivery.Application.Features.Orders.Queries.GetOrderWithDetailByManager;
using MetroDelivery.Application.Features.Orders.Queries.GetOrderWithOrderDetailByIdCustomer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Orders
{
    [Route("api/v1/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public OrdersController(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<OrderResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetListOrderQuery());
            return response;
        }

        [HttpGet]
        [Route("customers/{customerid}")]
        /*[Authorize(Roles = "EndUser")]*/
        public async Task<List<OrderResponse>> Get(string customerid)
        {
            var response = await _mediator.Send(new GetByIdCustomerQuery
            {
                CustomerId = customerid
            });
            return response;
        }

        [HttpGet]
        [Route("stores/{storeid}")]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<List<OrderResponse>> GetByStoreId(string storeid)
        {
            var response = await _mediator.Send(new GetOrderByManagerQuery
            {
                StoreId = storeid
            });
            return response;
        }

        [HttpGet]
        [Route("orderdetails/customers/{customerid}")]
        /*[Authorize(Roles = "EndUser")]*/
        public async Task<List<OrderRequest>> GetWithDetailCus(string customerid)
        {
            var response = await _mediator.Send(new GetOrderWithOrderDetailByIdCustomerQuery
            {
                CustomerId = customerid
            });
            return response;
        }

        [HttpGet]
        [Route("orderdetails/stores/{storeid}")]
        public async Task<List<OrderRequest>> GetWithDetailStore(string storeid)
        {
            var response = await _mediator.Send(new GetOrderWithDetailByManagerQuery
            {
                StoreId = storeid
            });
            return response;
        }

        [HttpPost] 
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        /*[Authorize(Roles = "EndUser")]*/
        public async Task<MetroPickUpResponse> CreateOrder(CreateOrderCommand request)
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
        public async Task<MetroPickUpResponse> Update(UpdateOrderCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
