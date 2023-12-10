using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Menu_Products.Commands.DeleteMenuProduct
{
    public class DeleteMenuProductCommand : IRequest<MetroPickUpResponse>
    {
        public string MenuProductId { get; set; }
    }

    public class DeleteMenuProductCommandHandler : IRequestHandler<DeleteMenuProductCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteMenuProductCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteMenuProductCommand request, CancellationToken cancellationToken)
        {
            var productMenuExist = await _metroPickUpDbContext.Menu_Product.Where(m => m.Id == Guid.Parse(request.MenuProductId)).SingleOrDefaultAsync();
            if (productMenuExist == null) {
                throw new NotFoundException($"MenuProduct does not exist !");
            }
            if (productMenuExist.IsDelete == true) {
                throw new NotFoundException($"MenuProduct is deleted !");
            }

            productMenuExist.IsDelete = true;
            _metroPickUpDbContext.Menu_Product.Update(productMenuExist);
            await _metroPickUpDbContext.SaveChangesAsync();
            return new MetroPickUpResponse
            {
                Message = "Delete MenuProduct Successfully"
            };
        }
    }
}
