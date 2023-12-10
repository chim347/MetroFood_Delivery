using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Route_Stations.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Trips.Queries.GetAllTrip
{
    public class GetListTripQuery : IRequest<List<TripResponse>>
    {
    }

    public class GetListTripQueryHandler : IRequestHandler<GetListTripQuery, List<TripResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListTripQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<TripResponse>> Handle(GetListTripQuery request, CancellationToken cancellationToken)
        {
            var list = await _metroPickUpDbContext.Trip.Where(t => !t.IsDelete)
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
