using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Stores.Queries.GetAllStores
{
    public class GetListStoreQueriesHandler : IRequestHandler<GetListStoreQueries, List<StoreDto>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListStoreQueriesHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }
        public async Task<List<StoreDto>> Handle(GetListStoreQueries request, CancellationToken cancellationToken)
        {
            var storeList = await _metroPickUpDbContext.Store.Where(s => !s.IsDelete).ToListAsync();

            var data = _mapper.Map<List<StoreDto>>(storeList);

            return data;

        }
    }
}
