using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Stations.Commands.UpdateStation
{
    public class UpdateStationCommandHandler : IRequestHandler<UpdateStationCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public UpdateStationCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(UpdateStationCommand request, CancellationToken cancellationToken)
        {
            // không được sủa StoreID trong station, nếu muốn sửa thì phải xóa sân ga và create sân ga mới có storeId
            var stationExist = await _metroPickUpDbContext.Station.Where(s => s.IsDelete == false && s.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if(stationExist == null) {
                throw new NotFoundException("StationId này không tồn tại hoặc đã bị xóa");
            }
            if (stationExist.StoreID != Guid.Parse(request.StoreID)) {
                throw new NotFoundException($"Không phải StoreId của sân ga {stationExist.Id}");
            }

            stationExist.StationName = request.StationName;
            

            _metroPickUpDbContext.Station.Update(stationExist);
            await _metroPickUpDbContext.SaveChangesAsync(cancellationToken);

            return new MetroPickUpResponse
            {
                Message = "Update station Successfully"
            };
        }
    }
}
