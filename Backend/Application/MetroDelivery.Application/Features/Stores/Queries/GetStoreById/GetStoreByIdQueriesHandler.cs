using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Stores.Queries.GetStoreById
{
    public class GetStoreByIdQueriesHandler : IRequestHandler<GetStoreByIdQueries, StoreDto>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetStoreByIdQueriesHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<StoreDto> Handle(GetStoreByIdQueries request, CancellationToken cancellationToken)
        {
            var storeId = await _metroPickUpDbContext.Store.Where(s => s.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (storeId == null) {
                throw new NotFoundException(nameof(Store), request.Id);
            }
            else if (storeId.IsDelete == true) {
                throw new NotFoundException($"{storeId} does not exist.");
            }

            var data = _mapper.Map<StoreDto>(storeId);

            return data;
        }
    }
}
