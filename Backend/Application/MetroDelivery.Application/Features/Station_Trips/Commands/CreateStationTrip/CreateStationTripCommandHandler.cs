using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MetroDelivery.Application.Features.Station_Trips.Commands.CreateStationTrip
{
    public class CreateStationTripCommandHandler : IRequestHandler<CreateStationTripCommand, Guid>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        public CreateStationTripCommandHandler(IMetroPickUpDbContext metroPickUpDbContext)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
        }

        public async Task<Guid> Handle(CreateStationTripCommand request, CancellationToken cancellationToken)
        {
            var tripExist = await _metroPickUpDbContext.Trip.Where(s => s.TripName == request.TripName
                                                                                    && s.TripStartTime == request.TripStartTime
                                                                                    && s.TripEndTime == request.TripEndTime
                                                                                    && s.Route.FromLocation == request.FromLocation
                                                                                    && s.Route.ToLocation == request.ToLocation
                                                                                    && !s.IsDelete).SingleOrDefaultAsync();
            // kiểm tra để tạo trip
            if(tripExist == null) {
                // kiểm tra route
                var routeExist = await _metroPickUpDbContext.Route.Where(r => r.FromLocation == request.FromLocation
                                                                            && r.ToLocation == request.ToLocation
                                                                            && r.IsDelete == false)
                                                                            .SingleOrDefaultAsync();
                if (routeExist != null) {
                    // tạo trip
                    var trip = new Trip
                    {
                        TripName = request.TripName,
                        TripStartTime = request.TripStartTime,
                        TripEndTime = request.TripEndTime,
                        RouteId = routeExist.Id,
                    };

                    _metroPickUpDbContext.Trip.Add(trip);
                    await _metroPickUpDbContext.SaveChangesAsync();
                    // tạo stationTrip, Trip với List station
                    var requestStation = request.StationList.Select(s => Guid.Parse(s.StationId)).ToList();
                    var stationExist = await _metroPickUpDbContext.Station.Where(s => requestStation.Contains(s.Id) && !s.IsDelete).ToListAsync();

                    if (stationExist.Count() == 0) {
                        throw new NotFoundException($"không tìm thấy station nào hết, cần phải tạo station");
                    }
                    foreach (var stationData in request.StationList) {
                        var station = stationExist.FirstOrDefault(s => s.Id == Guid.Parse(stationData.StationId));
                        if (station == null) {
                            throw new NotFoundException($"Không tìm thấy station {station} này!");
                        }
                        var stationTrip = new Station_Trip();
                        stationTrip.StationID = station.Id;
                        stationTrip.TripID = trip.Id;
                        stationTrip.Arrived = stationData.Arrived;

                        _metroPickUpDbContext.Station_Trip.Add(stationTrip);
                    }
                    await _metroPickUpDbContext.SaveChangesAsync();
                    return trip.Id;
                }
                else {
                    // tạo route
                    var route = new Route
                    {
                        FromLocation = request.FromLocation,
                        ToLocation = request.ToLocation,
                    };
                    _metroPickUpDbContext.Route.Add(route);
                    await _metroPickUpDbContext.SaveChangesAsync();

                    // tạo trip
                    var trip = new Trip
                    {
                        TripName = request.TripName,
                        TripStartTime = request.TripStartTime,
                        TripEndTime = request.TripEndTime,
                        RouteId = route.Id,
                    };

                    _metroPickUpDbContext.Trip.Add(trip);
                    await _metroPickUpDbContext.SaveChangesAsync();
                    // tạo stationTrip, Trip với List station
                    var requestStation = request.StationList.Select(s => Guid.Parse(s.StationId)).ToList();
                    var stationExist = await _metroPickUpDbContext.Station.Where(s => requestStation.Contains(s.Id) && !s.IsDelete).ToListAsync();

                    if (stationExist.Count() == 0) {
                        throw new NotFoundException($"không tìm thấy station nào hết, cần phải tạo station");
                    }
                    foreach (var stationData in request.StationList) {
                        var station = stationExist.FirstOrDefault(s => s.Id == Guid.Parse(stationData.StationId));
                        if (station == null) {
                            throw new NotFoundException($"Không tìm thấy station {station} này!");
                        }
                        var stationTrip = new Station_Trip();
                        stationTrip.StationID = station.Id;
                        stationTrip.TripID = trip.Id;
                        stationTrip.Arrived = stationData.Arrived;

                        _metroPickUpDbContext.Station_Trip.Add(stationTrip);
                    }
                    await _metroPickUpDbContext.SaveChangesAsync();
                    return trip.Id;
                }

            }
            else {
                // tạo stationTrip, Trip với List station
                var requestStation = request.StationList.Select(s => Guid.Parse(s.StationId)).ToList();
                var stationTripExist = await _metroPickUpDbContext.Station_Trip.Where(s => requestStation.Contains(s.Station.Id)
                                                                                        && s.Trip.TripName == request.TripName
                                                                                        && s.Trip.TripStartTime == request.TripStartTime
                                                                                        && s.Trip.TripEndTime == request.TripEndTime
                                                                                        && s.Trip.Route.FromLocation == request.FromLocation
                                                                                        && s.Trip.Route.ToLocation == request.ToLocation
                                                                                        && !s.IsDelete).ToListAsync();
                if (stationTripExist.Any()) {
                    throw new NotFoundException($"Trip đã tồn tại với station {stationTripExist} này rồi!!");
                }
                var stationExist = await _metroPickUpDbContext.Station.Where(s => requestStation.Contains(s.Id) && !s.IsDelete).ToListAsync();

                if (stationExist.Count() == 0) {
                    throw new NotFoundException($"không tìm thấy station nào hết, cần phải tạo station");
                }
                foreach (var stationData in request.StationList) {
                    var station = stationExist.FirstOrDefault(s => s.Id == Guid.Parse(stationData.StationId));
                    if (station == null) {
                        throw new NotFoundException($"Không tìm thấy station {station} này!");
                    }
                    var stationTrip = new Station_Trip();
                    stationTrip.StationID = station.Id;
                    stationTrip.TripID = tripExist.Id;
                    stationTrip.Arrived = stationData.Arrived;

                    _metroPickUpDbContext.Station_Trip.Add(stationTrip);
                }
                await _metroPickUpDbContext.SaveChangesAsync();
                return tripExist.Id;
            }
        }
    }
}
