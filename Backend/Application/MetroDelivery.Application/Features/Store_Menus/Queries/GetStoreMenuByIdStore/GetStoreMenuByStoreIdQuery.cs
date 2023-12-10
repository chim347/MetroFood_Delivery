using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Store_Menus.Queries.GetStoreMenuByIdStore
{
    public class GetStoreMenuByStoreIdQuery : IRequest<List<StoreMenuResponse>>
    {
        public string StoreId { get; set; }
    }

    public class GetStoreMenuByStoreIdQueryHandler : IRequestHandler<GetStoreMenuByStoreIdQuery, List<StoreMenuResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetStoreMenuByStoreIdQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<StoreMenuResponse>> Handle(GetStoreMenuByStoreIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _metroPickUpDbContext.Store_Menu.Where(s => !s.IsDelete && s.StoreId == Guid.Parse(request.StoreId))
                                                                .Join(
                                                                    _metroPickUpDbContext.Store,
                                                                    storeMenu => storeMenu.StoreId,
                                                                    store => store.Id,
                                                                    (storeMenu, store) => new
                                                                    {
                                                                        StoreMenus = storeMenu,
                                                                        Stores = store
                                                                    }
                                                                )
                                                                .Join(
                                                                    _metroPickUpDbContext.Menu,
                                                                    combined => combined.StoreMenus.MenuId,
                                                                    menu => menu.Id,
                                                                    (combined, menu) => new StoreMenuResponse
                                                                    {
                                                                        Id = combined.StoreMenus.Id,
                                                                        StoreId = combined.StoreMenus.StoreId,
                                                                        MenuId = combined.StoreMenus.MenuId,
                                                                        ApplyDate = combined.StoreMenus.ApplyDate,
                                                                        Priority = combined.StoreMenus.Priority,
                                                                        Create = combined.StoreMenus.Created,

                                                                        StoreData = _mapper.Map<StoreData>(combined.Stores),
                                                                        MenuData = _mapper.Map<MenuData>(menu)
                                                                    }
                                                                ).ToListAsync();

            return result;
        }
    }
}
