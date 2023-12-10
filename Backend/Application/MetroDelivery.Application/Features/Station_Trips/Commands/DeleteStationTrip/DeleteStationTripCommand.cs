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

namespace MetroDelivery.Application.Features.Station_Trips.Commands.DeleteStationTrip
{
    public class DeleteStationTripCommand : IRequest<MetroPickUpResponse>
    { 
        public string Id { get; set; }
    }

    public class DeleteStationTripCommandHandler : IRequestHandler<DeleteStationTripCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteStationTripCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteStationTripCommand request, CancellationToken cancellationToken)
        {
            var stationTripExist = await _metroPickUpDbContext.Station_Trip.Where(s => s.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if(stationTripExist == null) {
                throw new NotFoundException($"không tìm thấy stationTripId nào hết");
            }
            if (stationTripExist.IsDelete == true) {
                throw new NotFoundException($"stationTripId đã bị xóa");
            }

            stationTripExist.IsDelete = true;
            _metroPickUpDbContext.Station_Trip.Update(stationTripExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Delete Successfully"
            };
        }
    }
}
