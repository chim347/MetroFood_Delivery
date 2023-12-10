using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Stations.Commands.CreateStation;
using MetroDelivery.Application.Features.Stations.Commands.DeleteStation;
using MetroDelivery.Application.Features.Stations.Commands.UpdateStation;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Application.Features.Stations.Queries.GetAllStation;
using MetroDelivery.Application.Features.Stations.Queries.GetByIdStore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Stations
{
    [Route("api/v1/stations")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        
        public async Task<List<StationResponse>> GetAllStation()
        {
            var response = await _mediator.Send(new GetListStationQuery());   
            return response;
        }

        // GET api/<StationsController>/5
        [HttpGet]
        [Route("{stationid}")]
        public async Task<StationResponse> Get(string stationid)
        {
            var response = await _mediator.Send(new GetStationByIdStoreQuery
            {
                StationId = stationid
            });
            return response;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<ActionResult> Create([FromBody] CreateStationCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetAllStation), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> Update(UpdateStationCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> Delete([FromQuery] DeleteStationCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
