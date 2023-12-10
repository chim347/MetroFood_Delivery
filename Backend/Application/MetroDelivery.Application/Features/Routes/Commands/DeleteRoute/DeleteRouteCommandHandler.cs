using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Routes.Commands.DeleteRoute
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteRouteCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var routeExist = await _metroPickUpDbContext.Route.Where(r => r.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (routeExist == null) {
                throw new NotFoundException("RouteId do not exsit!!!");
            }
            if (routeExist.IsDelete == true) {
                throw new NotFoundException("RouteId is deleted !!");
            }

            routeExist.IsDelete = true;
            _metroPickUpDbContext.Route.Update(routeExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Delete Route Exist!!!"
            };
        }
    }
}
