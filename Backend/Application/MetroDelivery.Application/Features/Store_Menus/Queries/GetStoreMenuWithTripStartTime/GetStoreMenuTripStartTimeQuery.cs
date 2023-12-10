using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Store_Menus.Queries.GetStoreMenuWithTripStartTime
{
    public class GetStoreMenuTripStartTimeQuery : IRequest<StoreMenuResponse>
    {
        public string? StationTripId { get; set; }
    }

    public class GetStoreMenuTripStartTimeQueryHandler : IRequestHandler<GetStoreMenuTripStartTimeQuery, StoreMenuResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetStoreMenuTripStartTimeQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<StoreMenuResponse> Handle(GetStoreMenuTripStartTimeQuery request, CancellationToken cancellationToken)
        {
            var tripTime = await _metroPickUpDbContext.Station_Trip.Where(s => s.Id == Guid.Parse(request.StationTripId)).Select(s => s.Arrived).SingleOrDefaultAsync();
            var tripStationByStoreId =  await _metroPickUpDbContext.Station.Where(s => s.Id == Guid.Parse(request.StationTripId)).SingleOrDefaultAsync();


            // lấy thời gian đến trạm của chuyến tàu đó (station_trip) đem đi so sánh với thời gian của Menu để lấy cái Menu phù hợp với khung giờ của chuyến tàu đó
            // đến trạm lúc thời gian phục vụ và bắt đầu, chứ đến trạm mà hết thời gian phụ vụ coi như menu đó ko hiện, chuyển đến menu tiếp theo
            /*var menus = await _metroPickUpDbContext.Menu.Where(m => (m.StartTimeService <= tripTime.TimeOfDay) && (m.EndTimeService > tripTime.TimeOfDay)).SingleOrDefaultAsync();*/

            /*var menus = await _metroPickUpDbContext.Store_Menu.Where(s => (s.Menu.StartTimeService <= tripTime.TimeOfDay)
                                                                       && (s.Menu.EndTimeService > tripTime.TimeOfDay)
                                                                       && s.Priority == true
                                                                       ).Select(s => s.MenuId).SingleOrDefaultAsync();*/

            if (tripStationByStoreId == null) {
                throw new NotFoundException("Station does not exist!!!");
            }

            var result = await _metroPickUpDbContext.Store_Menu.Where(s => !s.IsDelete 
                                                                        && (s.Menu.StartTimeService <= tripTime.TimeOfDay)
                                                                        && (s.Menu.EndTimeService > tripTime.TimeOfDay)
                                                                        && s.Priority == true
                                                                        && s.StoreId == tripStationByStoreId.StoreID)
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
                                                                ).SingleOrDefaultAsync();
            if(result == null) {
                throw new NotFoundException("không có Store Menu nào");
            }
            return result;
        }
    }
}
