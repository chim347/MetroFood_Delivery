using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Store_Menus.Commands.DeleteStoreMenu
{
    public class DeleteStoreMenuCommand : IRequest<MetroPickUpResponse>
    {
        public string StoreMenuId { get ; set; }
    }

    public class DeleteStoreMenuCommandHandler : IRequestHandler<DeleteStoreMenuCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteStoreMenuCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteStoreMenuCommand request, CancellationToken cancellationToken)
        {
            var storeMenuExist = await _metroPickUpDbContext.Store_Menu.Where(s => s.Id == Guid.Parse(request.StoreMenuId)).SingleOrDefaultAsync();
            if(storeMenuExist == null) {
                throw new NotFoundException($"Does not exist StoreMenuId");
            }
            if (storeMenuExist.IsDelete == true) {
                throw new NotFoundException($"StoreMenuId is deleted");
            }

            storeMenuExist.IsDelete = true;
            storeMenuExist.Priority = false;
            await _metroPickUpDbContext.SaveChangesAsync();
            return new MetroPickUpResponse { 
                Message = "Delete StoreMenu Successfully"
            };
        }
    }
}
