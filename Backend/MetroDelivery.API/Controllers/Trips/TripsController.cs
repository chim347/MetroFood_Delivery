using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Trips.Commands.CreateTrip;
using MetroDelivery.Application.Features.Trips.Commands.DeleteTrip;
using MetroDelivery.Application.Features.Trips.Commands.UpdateTrip;
using MetroDelivery.Application.Features.Trips.Queries;
using MetroDelivery.Application.Features.Trips.Queries.GetAllTrip;
using MetroDelivery.Application.Features.Trips.Queries.GetRouteInTrips;
using Microsoft.AspNetCore.Mvc;

namespace MetroDelivery.API.Controllers.Trips
{
    [Route("api/v1/trips")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TripsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<TripResponse>> GetAllTrip()
        {
            var response = await _mediator.Send(new GetListTripQuery());
            return response;
        }

        [HttpGet]
        [Route("routes/{fromlocation}/{tolocation}")]
        public async Task<List<TripResponse>> GetRouteInTrip(string fromlocation, string tolocation)
        {
            var response = await _mediator.Send(new GetRouteInTripQuery
            {
                FromLocation = fromlocation,
                ToLocation = tolocation
            });
            return response;
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<ActionResult> Create([FromQuery] CreateTripCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetAllTrip), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> Update(UpdateTripCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> Delete(string id)
        {
            var response = await _mediator.Send(new DeleteTripCommand
            {
                Id = id
            });
            return response;
        }
    }
}
