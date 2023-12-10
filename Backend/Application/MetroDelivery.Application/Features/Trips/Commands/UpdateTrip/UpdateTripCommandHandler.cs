using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Trips.Commands.UpdateTrip
{
    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
       
        public UpdateTripCommandHandler(IMetroPickUpDbContext metroPickUpDbContext)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            
        }

        public async Task<MetroPickUpResponse> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var tripId = await _metroPickUpDbContext.Trip.Where(t => t.Id == Guid.Parse(request.TripId)).SingleOrDefaultAsync();
            var routeId = await _metroPickUpDbContext.Route.Where(r => r.Id == Guid.Parse(request.RouteId)).SingleOrDefaultAsync();
            if (tripId == null) {
                throw new NotFoundException("Not found trip");
            }
            if(tripId.IsDelete == true) {
                throw new NotFoundException("Trip is delete!!");
            }
            if (routeId == null) {
                throw new NotFoundException("Not found route");
            }
            if (routeId.IsDelete == true) {
                throw new NotFoundException("Route is delete!!");
            }

            tripId.TripName = request.TripName;
            tripId.TripStartTime = request.TripStartTime;
            tripId.TripEndTime = request.TripEndTime;
            tripId.RouteId = Guid.Parse(request.RouteId);
            
            _metroPickUpDbContext.Trip.Update(tripId);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Update Successfully"
            };
        }
    }
}
