using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Products.Commands.DeleteProducts
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteProductCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productIdExisted = await _metroPickUpDbContext.Product.Where(p => p.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (productIdExisted == null) {
                throw new NotFoundException($"ProductId {request.Id} không tồn tại");
            }
            if(productIdExisted.IsDelete == true) {
                throw new NotFoundException($"ProductId {request.Id} đã bị xóa khỏi danh sách Product");
            }

            productIdExisted.IsDelete = true;
            _metroPickUpDbContext.Product.Update(productIdExisted);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Delete Product Successfully"
            };
        }
    }
}
