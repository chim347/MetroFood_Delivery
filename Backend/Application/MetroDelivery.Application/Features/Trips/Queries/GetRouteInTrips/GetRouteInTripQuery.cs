using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Routes.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Trips.Queries.GetRouteInTrips
{
    public class GetRouteInTripQuery : IRequest<List<TripResponse>>
    {
        public string? FromLocation { get; set; }
        public string? ToLocation { get; set; }
    }

    public class GetRouteInTripQueryHandler : IRequestHandler<GetRouteInTripQuery, List<TripResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetRouteInTripQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<TripResponse>> Handle(GetRouteInTripQuery request, CancellationToken cancellationToken)
        {
            /*var routeExist = await _metroPickUpDbContext.Route.Where(r => r.FromLocation == request.FromLocation && r.ToLocation == request.ToLocation).ToListAsync();
            if(routeExist.Count() == 0) {
                throw new NotFoundException("Không có from and to nào route hết");
            }

            foreach(var route in routeExist) {

            }*/
            var list = await _metroPickUpDbContext.Trip.Where(t => !t.IsDelete && t.Route.FromLocation == request.FromLocation && t.Route.ToLocation == request.ToLocation)
                                                    .Join(
                                                        _metroPickUpDbContext.Route,
                                                        trip => trip.RouteId,
                                                        route => route.Id,
                                                        (trip, route) => new TripResponse
                                                        {
                                                            Id = trip.Id,
                                                            TripName = trip.TripName,
                                                            TripStartTime = trip.TripStartTime,
                                                            TripEndTime = trip.TripEndTime,
                                                            RouteId = trip.RouteId,

                                                            RouteData = _mapper.Map<RouteData>(route)
                                                        }
                                                    )
                                                    .ToListAsync();

            return list;
        }
        
    }
}
