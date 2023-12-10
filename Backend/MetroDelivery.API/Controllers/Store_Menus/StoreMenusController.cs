using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Store_Menus.Commands.CreateStoreMenu;
using MetroDelivery.Application.Features.Store_Menus.Commands.DeleteStoreMenu;
using MetroDelivery.Application.Features.Store_Menus.Commands.UpdateStoreMenu;
using MetroDelivery.Application.Features.Store_Menus.Queries;
using MetroDelivery.Application.Features.Store_Menus.Queries.GetAllStoreMenu;
using MetroDelivery.Application.Features.Store_Menus.Queries.GetStoreMenuByIdStore;
using MetroDelivery.Application.Features.Store_Menus.Queries.GetStoreMenuWithTripStartTime;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Store_Menus
{
    [Route("api/v1/store-menus")]
    [ApiController]
    public class StoreMenusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreMenusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<StoreMenuResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetListStoreMenuQuery());
            return response;
        }

        [HttpGet]
        [Route("stations/{stationtripid}")]
        public async Task<StoreMenuResponse> GetWithTimeStartTrip(string stationtripid)
        {
            var response = await _mediator.Send(new GetStoreMenuTripStartTimeQuery
            {
                StationTripId = stationtripid
            });
            return response;
        }

        [HttpGet]
        [Route("{storeid}")]
        public async Task<List<StoreMenuResponse>> Get(string storeid)
        {
            var response = await _mediator.Send(new GetStoreMenuByStoreIdQuery
            {
                StoreId = storeid
            });
            return response;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> Create([FromBody] CreateStoreMenuCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<MetroPickUpResponse> Update(UpdateStoreMenuCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<MetroPickUpResponse> Delete([FromQuery] DeleteStoreMenuCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
