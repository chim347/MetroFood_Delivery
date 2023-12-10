using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Routes.Commands.CreateRoute
{
    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, Guid>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public CreateRouteCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            var routeExist = await _metroPickUpDbContext.Route.Where(r => r.FromLocation == request.FromLocation
                                                                            && r.ToLocation == request.ToLocation 
                                                                            && r.IsDelete == false)
                                                                            .SingleOrDefaultAsync();
            if(routeExist != null) {
                throw new NotFoundException("route is already existed");
            }

            var route = new Route
            {
                FromLocation = request.FromLocation,
                ToLocation = request.ToLocation,
            };
            _metroPickUpDbContext.Route.Add(route);
            await _metroPickUpDbContext.SaveChangesAsync();

            return route.Id;
        }
    }
}
