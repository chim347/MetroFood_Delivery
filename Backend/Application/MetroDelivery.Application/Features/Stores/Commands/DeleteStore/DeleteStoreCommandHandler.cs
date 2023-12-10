using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteStoreCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var storeExist = await _metroPickUpDbContext.Store.Where(s => s.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if(storeExist == null) {
                throw new NotFoundException("Không tìm thấy cửa hàng!!!");
            }
            if(storeExist.IsDelete == true) {
                throw new NotFoundException("Cửa hàng đã bị xóa!!!");
            }

            storeExist.IsDelete = true;
            _metroPickUpDbContext.Store.Update(storeExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Delete Store Successfully"
            };
        }
    }
}
