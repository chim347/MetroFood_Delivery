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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Store_Menus.Commands.UpdateStoreMenu
{
    public class UpdateStoreMenuCommand : IRequest<MetroPickUpResponse>
    {
        public string StoreId { get; set; }
        public string MenuId { get; set; }
    }

    public class UpdateStoreMenuCommandHandler : IRequestHandler<UpdateStoreMenuCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public UpdateStoreMenuCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(UpdateStoreMenuCommand request, CancellationToken cancellationToken)
        {
            var storeMenuExist = await _metroPickUpDbContext.Store_Menu.Where(s => s.StoreId == Guid.Parse(request.StoreId) && s.MenuId == Guid.Parse(request.MenuId) && !s.IsDelete).SingleOrDefaultAsync();
            if(storeMenuExist == null) {
                throw new NotFoundException($"Not Exist StoreMenuId with {request.StoreId} and {request.MenuId}");
            }
            var menu = await _metroPickUpDbContext.Menu.Where(m => m.Id == storeMenuExist.MenuId).SingleOrDefaultAsync();
            if (menu == null) {
                throw new NotFoundException($"Not Exist MenuId {request.MenuId}");
            }
            // kiểm tra coi có bao nhiêu menu theo khuing thười gian đó
            var storeMenuByTime = await _metroPickUpDbContext.Store_Menu.Where(s => s.Menu.StartTimeService == menu.StartTimeService
                                                                        && s.Menu.EndTimeService == menu.EndTimeService
                                                                        && !s.IsDelete).Select(s => s.MenuId).ToListAsync();
            var store = await _metroPickUpDbContext.Store_Menu.Where(s => s.StoreId == Guid.Parse(request.StoreId) && storeMenuByTime.Contains(s.MenuId) && !s.IsDelete).ToListAsync();

            if (storeMenuByTime.Count() == 0) {
                throw new NotFoundException("Cửa hàng chưa có menu này, bạn hãy tạo nó đi");
            }
            foreach(var menuPrior in store) {
                if(menuPrior.Priority == true) {
                    menuPrior.Priority = false;
                    _metroPickUpDbContext.Store_Menu.Update(menuPrior);
                    await _metroPickUpDbContext.SaveChangesAsync();
                }
            }

            storeMenuExist.Priority = true;
            _metroPickUpDbContext.Store_Menu.Update(storeMenuExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse{
                Message = "Update Store Menu Successfully"
            };
        }
    }
}
