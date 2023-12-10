using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Route_Stations.Queries.GetRouteInStation
{
    public class GetRouteInStationQuery : IRequest<List<RouteStationResponse>>
    {
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
    }

    public class GetRouteInStationQueryHandler : IRequestHandler<GetRouteInStationQuery, List<RouteStationResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetRouteInStationQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<RouteStationResponse>> Handle(GetRouteInStationQuery request, CancellationToken cancellationToken)
        {
            var routeStation = await _metroPickUpDbContext.Route_Station.Where(r => !r.IsDelete && r.Route.FromLocation == request.FromLocation && r.Route.ToLocation == request.ToLocation)
                                    .Join(
                                        _metroPickUpDbContext.Route,
                                        routeAndStation => routeAndStation.RouteID,
                                        route => route.Id,
                                        (routeAndStation, route) => new
                                        {
                                            Route_Stations = routeAndStation,
                                            Routes = route
                                        }
                                     )
                                    .Join(
                                        _metroPickUpDbContext.Station,
                                        combined => combined.Route_Stations.StationID,
                                        station => station.Id,
                                        (combined, station) => new RouteStationResponse
                                        {
                                            Id = combined.Route_Stations.Id,
                                            RouteID = combined.Route_Stations.RouteID,
                                            StationID = combined.Route_Stations.StationID,
                                            Index = combined.Route_Stations.Index,
                                            Duration = combined.Route_Stations.Duration,
                                            StopTime = combined.Route_Stations.StopTime,
                                            Created = combined.Route_Stations.Created,

                                            RouteData = combined.Routes,
                                            StationData = station
                                        }
                                    ).ToListAsync();
            return routeStation;
        }
    }
}
