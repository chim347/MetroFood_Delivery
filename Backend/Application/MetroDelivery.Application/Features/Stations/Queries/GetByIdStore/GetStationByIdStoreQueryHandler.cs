using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Stores.Queries.GetStoreById;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Stations.Queries.GetByIdStore
{
    public class GetStationByIdStoreQueryHandler : IRequestHandler<GetStationByIdStoreQuery, StationResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetStationByIdStoreQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<StationResponse> Handle(GetStationByIdStoreQuery request, CancellationToken cancellationToken)
        {
            var station = await _metroPickUpDbContext.Station.Where(s => s.Id == Guid.Parse(request.StationId)).SingleOrDefaultAsync();
            if (station == null) {
                throw new NotFoundException($"Not found station with {station}");
            }

            var stationData = _mapper.Map<StationData>(station);
            var storeId = await _metroPickUpDbContext.Store.Where(s => s.Id == station.StoreID).SingleOrDefaultAsync();
            var storeData = _mapper.Map<StoreData>(storeId);
            var result = new StationResponse
            {
                StationData = stationData,
                StoreData = storeData
            };

            return result;
        }
    }
}
