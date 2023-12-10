using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Stations.Commands.CreateStation
{
    public class CreateStationCommandHandler : IRequestHandler<CreateStationCommand, Guid>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public CreateStationCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateStationCommand request, CancellationToken cancellationToken)
        {
            var stationExistStore = await _metroPickUpDbContext.Station.Where(s => s.StoreID == request.StoreID && s.IsDelete == false).SingleOrDefaultAsync();

            if (stationExistStore != null) {
                throw new NotFoundException($"Cửa hàng rồi đã tồn tại ở sân ga {stationExistStore.Id} rồi!!!!");
            }

            var station = new Station
            {
                StoreID = request.StoreID,
                StationName = request.StationName,
            };

            _metroPickUpDbContext.Station.Add(station);
            await _metroPickUpDbContext.SaveChangesAsync();

            return station.StoreID;
        }
    }
}
