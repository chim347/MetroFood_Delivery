using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Routes.Commands.UpdateRoute
{
    public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public UpdateRouteCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            var routeExist = await _metroPickUpDbContext.Route.Where(r => r.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if(routeExist == null) {
                throw new NotFoundException("RouteId do not exsit!!!");
            }
            if (routeExist.IsDelete == true) {
                throw new NotFoundException("RouteId is deleted !!");
            }

            routeExist.FromLocation = request.FromLocation;
            routeExist.ToLocation = request.ToLocation;

            _metroPickUpDbContext.Route.Update(routeExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse { 
                Message = "Update Route Successfully"
            };   
        }
    }
}
