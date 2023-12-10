using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Routes.Queries.GetAllRoute
{
    public class GetListRouteQueryHandler : IRequestHandler<GetListRouteQuery, List<RouteResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListRouteQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<RouteResponse>> Handle(GetListRouteQuery request, CancellationToken cancellationToken)
        {
            var routeList = await _metroPickUpDbContext.Route.Where(r => r.IsDelete == false).ToListAsync();
            if(!routeList.Any()) {
                throw new NotFoundException("Không có route nào tồn tại trong Database");
            }

            var data = _mapper.Map<List<RouteResponse>>(routeList);

            return data;
        }
    }
}
