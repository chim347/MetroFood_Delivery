using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Menu_Products.Commands.CreateMenuProduct;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Menu_Products.Commands.UpdateMenuProduct
{
    public class UpdateMenuProductCommand : IRequest<MetroPickUpResponse>
    {
        public string MenuProductId { get; set; }
        // update gia tien thoi
        public double? PriceOfProductBelongToTimeService { get; set; }
    }

    public class UpdateMenuProductCommandHandler : IRequestHandler<UpdateMenuProductCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public UpdateMenuProductCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(UpdateMenuProductCommand request, CancellationToken cancellationToken)
        {
            // check productId đã tồn tại trong menuProductId này chưa
            var existingMenuProducts = await _metroPickUpDbContext.Menu_Product
                                            .Where(mp => mp.Id == Guid.Parse(request.MenuProductId))
                                            .SingleOrDefaultAsync();
            if (existingMenuProducts == null) {
                throw new NotFoundException($"product menu does not exist!");
            }
            if (existingMenuProducts.IsDelete == true) {
                throw new NotFoundException($"product menu is deleted!");
            }

            existingMenuProducts.PriceOfProductBelongToTimeService = request.PriceOfProductBelongToTimeService;

            _metroPickUpDbContext.Menu_Product.Update(existingMenuProducts);

            await _metroPickUpDbContext.SaveChangesAsync();
            return new MetroPickUpResponse
            {
                Message = "Update Menu Product Successfully"
            };
        }
    }
}
