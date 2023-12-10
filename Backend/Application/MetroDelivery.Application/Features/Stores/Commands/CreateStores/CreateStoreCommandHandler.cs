using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Stores.Commands.CreateStores
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, Guid>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public CreateStoreCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var storeExistLocation = await _metroPickUpDbContext.Store.Where(s => s.StoreLocation == request.StoreLocation && s.IsDelete == false).SingleOrDefaultAsync();
            if (storeExistLocation != null) {
                throw new NotFoundException("Cửa hàng này đã tồn tại rồi!!!");
            }

            var store = new Store
            {
                StoreName = request.StoreName,
                StoreLocation = request.StoreLocation,
                StoreOpenTime = request.StoreOpenTime,
                StoreCloseTime = request.StoreCloseTime
            };

            _metroPickUpDbContext.Store.Add(store);
            await _metroPickUpDbContext.SaveChangesAsync();

            return store.Id;
        }
    }
}
