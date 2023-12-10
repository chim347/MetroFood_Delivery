using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Routes.Queries.GetByFromToRoute
{
    public class GetRouteByFromToQuery : IRequest<RouteResponse>
    {
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
    }

    public class GetRouteByFromToQueryHandler : IRequestHandler<GetRouteByFromToQuery, RouteResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetRouteByFromToQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<RouteResponse> Handle(GetRouteByFromToQuery request, CancellationToken cancellationToken)
        {
            var routeExist = await _metroPickUpDbContext.Route.Where(r => r.FromLocation == request.FromLocation && r.ToLocation == request.ToLocation && !r.IsDelete).SingleOrDefaultAsync();
            if (routeExist == null) {
                throw new NotFoundException("Không có from and to nào route hết");
            }

            var data = _mapper.Map<RouteResponse>(routeExist);

            return data;
        }
    }
}
