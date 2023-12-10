using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public UpdateStoreCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var storeExist = await _metroPickUpDbContext.Store.Where(s => s.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (storeExist == null) {
                throw new NotFoundException("Không tìm thấy cửa hàng!!!");
            }
            if (storeExist.IsDelete == true) {
                throw new NotFoundException("Cửa hàng đã bị xóa!!!");
            }

            storeExist.StoreName = request.StoreName;
            storeExist.StoreLocation = request.StoreLocation;
            storeExist.StoreOpenTime = request.StoreOpenTime;
            storeExist.StoreCloseTime = request.StoreCloseTime;

            _metroPickUpDbContext.Store.Update(storeExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Update Store Successfully"
            };
        }
    }
}
