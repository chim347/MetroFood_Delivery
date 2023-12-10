using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Categorys.Commands.UpdateCategory;
using MetroDelivery.Application.Features.Menu_Products;
using MetroDelivery.Application.Features.Menu_Products.Commands.CreateMenuProduct;
using MetroDelivery.Application.Features.Menu_Products.Commands.DeleteMenuProduct;
using MetroDelivery.Application.Features.Menu_Products.Commands.UpdateMenuProduct;
using MetroDelivery.Application.Features.Menu_Products.Queries.GetListMenu_Product;
using MetroDelivery.Application.Features.Menu_Products.Queries.GetMenuProductByMenuId;
using MetroDelivery.Application.Features.Menu_Products.Queries.GetMenuProductByTimeService;
using MetroDelivery.Application.Features.Menus.Commands.CreateMenu;
using MetroDelivery.Application.Features.Menus.Commands.DeleteMenu;
using MetroDelivery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Menu_Products
{
    [Route("api/v1/menu-products")]
    [ApiController]
    public class MenuProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<MenuProductResponse>> Get()
        {
            var response = await _mediator.Send(new GetAllMenu_Products());
            return response;
        }

        [HttpGet]
        [Route("stations/{stationid}")]
        public async Task<MenuProductResponseData> GetStationId(string stationid)
        {
            var request = new GetMenuProductByStationIdQuery { StationId = stationid };
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpGet]
        [Route("menus/{menuid}")]
        public async Task<List<MenuProductResponse>> GetMenuId(string menuid)
        {
            var request = new GetMenuProducByMenuIdQuery { menuId = menuid };
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<MetroPickUpResponse> Create([FromBody] CreateMenuProductCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<MetroPickUpResponse> Update(UpdateMenuProductCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpDelete]
        [Route("{menuproductid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<MetroPickUpResponse> Delete(string menuproductid)
        {
            var request = new DeleteMenuProductCommand { MenuProductId = menuproductid };
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
