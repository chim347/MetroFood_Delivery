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

namespace MetroDelivery.Application.Features.Stations.Commands.DeleteStation
{
    public class DeleteStationCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
    }

    public class DeleteStationCommandHandler : IRequestHandler<DeleteStationCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteStationCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteStationCommand request, CancellationToken cancellationToken)
        {
            var stationExist = await _metroPickUpDbContext.Station.Where(s => s.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (stationExist == null) {
                throw new NotFoundException("StationId này không tồn tại");
            }
            if(stationExist.IsDelete == true) {
                throw new NotFoundException("StationId này đã được xóa!!");
            }

            stationExist.IsDelete = true;
            _metroPickUpDbContext.Station.Update(stationExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Delete Successfully"
            };
        }
    }
}
