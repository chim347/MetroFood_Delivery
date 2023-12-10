using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Application.Features.Trips.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Station_Trips.Queries.GetAllStationTrip
{
    public class GetListStationTripQuery : IRequest<List<StationTripResponse>>
    {
    }

    public class GetListStationTripQueryHandler : IRequestHandler<GetListStationTripQuery, List<StationTripResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListStationTripQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<StationTripResponse>> Handle(GetListStationTripQuery request, CancellationToken cancellationToken)
        {
            /* var listStationTrip = await _metroPickUpDbContext.Station_Trip.Where(s => !s.IsDelete)
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
                                                                         (combined, trip) => new StationTripResponse
                                                                         {
                                                                             Id = combined.StationTrip.Id,
                                                                             Arrived = combined.StationTrip.Arrived,
                                                                             StationID = combined.StationTrip.StationID,
                                                                             TripID = combined.StationTrip.TripID,

                                                                             StationData = _mapper.Map<StationData>(combined.Stations),
                                                                             TripData = _mapper.Map<TripResponse>(trip)
                                                                         }
                                                                     ).ToListAsync();*/
            var listStationTrip = await _metroPickUpDbContext.Station_Trip.Where(s => !s.IsDelete)
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


            return listStationTrip;
        }
    }
}
