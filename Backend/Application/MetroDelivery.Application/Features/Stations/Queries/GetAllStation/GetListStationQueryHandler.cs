using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Stations.Queries.GetAllStation
{
    public class GetListStationQueryHandler : IRequestHandler<GetListStationQuery, List<StationResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListStationQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }
        public async Task<List<StationResponse>> Handle(GetListStationQuery request, CancellationToken cancellationToken)
        {
            var station = await _metroPickUpDbContext.Station.Where(s => s.IsDelete == false).ToListAsync();
            if(!station.Any()) {
                throw new NotFoundException("Not found station!!!");
            }
            var listResult = new List<StationResponse>();
            foreach (var item in station) {
                try {
                    var stationData = _mapper.Map<StationData>(item);
                    var storeId = await _metroPickUpDbContext.Store.Where(s => s.Id ==  item.StoreID).SingleOrDefaultAsync();
                    var storeData = _mapper.Map<StoreData>(storeId);
                    var result = new StationResponse
                    {
                        StationData = stationData,
                        StoreData = storeData
                    };
                    listResult.Add(result);
                }catch(Exception ex) {
                    throw new BadRequestException(ex.Message);
                }
            }
            return listResult;
        }
    }
}
