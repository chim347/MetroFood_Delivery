using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Application.Features.Trips.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Station_Trips.Queries.GetStationByTripId
{
    public class GetStationByTripIdQuery : IRequest<List<StationTripResponse>>
    {
        public string TripId { get; set; }
    }

    public class GetStationByTripIdQueryHandler : IRequestHandler<GetStationByTripIdQuery, List<StationTripResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetStationByTripIdQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<StationTripResponse>> Handle(GetStationByTripIdQuery request, CancellationToken cancellationToken)
        {
            var listStationTrip = await _metroPickUpDbContext.Station_Trip.Where(s => !s.IsDelete && s.Trip.Id == Guid.Parse(request.TripId))
                                                             .Join(
                                                                 _metroPickUpDbContext.Station,
                                                                 stationTrip => stationTrip.StationID,
                                                                 station => station.Id,
                                                                 (stationTrip, station) => new
                                                                 {
                                                                     StationTrip = stationTrip,
                                                                     Stations = station
                                                                 }
                                                             )
                                                             .Join(
                                                                 _metroPickUpDbContext.Trip,
                                                                 combined => combined.StationTrip.TripID,
                                                                 trip => trip.Id,
                                                                 (combined, trip) => new
                                                                 {
                                                                     combined.StationTrip,
                                                                     combined.Stations,
                                                                     Trip = trip
                                                                 }
                                                             )
                                                             .Join(
                                                                 _metroPickUpDbContext.Route,
                                                                 combined => combined.Trip.RouteId,
                                                                 route => route.Id,
                                                                 (combined, route) => new StationTripResponse
                                                                 {
                                                                     Id = combined.StationTrip.Id,
                                                                     Arrived = combined.StationTrip.Arrived,
                                                                     StationID = combined.StationTrip.StationID,
                                                                     TripID = combined.StationTrip.TripID,

                                                                     StationData = _mapper.Map<StationData>(combined.Stations),
                                                                     TripData = new TripResponse
                                                                     {
                                                                         Id = combined.Trip.Id,
                                                                         TripName = combined.Trip.TripName,
                                                                         TripStartTime = combined.Trip.TripStartTime,
                                                                         TripEndTime = combined.Trip.TripEndTime,
                                                                         RouteId = combined.Trip.RouteId,
                                                                         RouteData = _mapper.Map<RouteData>(route)
                                                                     }
                                                                 }
                                                             ).ToListAsync();
            if(listStationTrip.Count() == 0) {
                throw new NotFoundException($"chuyến tàu {request.TripId} này ko đến sân ga nào hết");
            }
            return listStationTrip;
        }
    }
}
