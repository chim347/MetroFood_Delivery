using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Menus.Queries;
using MetroDelivery.Application.Features.OrderDetails.Queries;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Menu_Products.Queries.GetMenuProductByTimeService
{
    public class GetMenuProductByStationIdQuery : IRequest<MenuProductResponseData>
    {
        public string StationId { get; set; }
    }

    public class GetMenuProductByStationIdQueryQueryHandler : IRequestHandler<GetMenuProductByStationIdQuery, MenuProductResponseData>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetMenuProductByStationIdQueryQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MenuProductResponseData> Handle(GetMenuProductByStationIdQuery request, CancellationToken cancellationToken)
        {
            var stationExist = await _metroPickUpDbContext.Station.Where(s => s.Id == Guid.Parse(request.StationId)).SingleOrDefaultAsync();
            if (stationExist == null) {
                throw new NotFoundException($"Not found station with {stationExist}");
            }
            if (stationExist.IsDelete == true) {
                throw new NotFoundException($"station đã bị xóa");
            }
            var storeExist = await _metroPickUpDbContext.Store.Where(s => s.Id == stationExist.StoreID).SingleOrDefaultAsync();


            // Lấy thông tin về múi giờ của Việt Nam
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            // Lấy thời gian hiện tại theo múi giờ của Việt Nam
            DateTime vietnamTime = TimeZoneInfo.ConvertTime(DateTime.Now, vietnamTimeZone);
            var currentDayOfWeek = vietnamTime.DayOfWeek;

            // kiểm tra ngày với priority trong StoreMenu nếu thỏa priority thì lấy ra 
            var storeMenus = await _metroPickUpDbContext.Store_Menu.Where(m => (m.Menu.StartTimeService <= vietnamTime.TimeOfDay)
                                                                    && (m.Menu.EndTimeService > vietnamTime.TimeOfDay)
                                                                    /* && m.ApplyDate == currentDayOfWeek.ToString()*/ // chỗ này là thứ mấy
                                                                    && m.Priority == true
                                                                    && m.StoreId == stationExist.StoreID)
                                                                    .SingleOrDefaultAsync();
            /* var storeMenus = await _metroPickUpDbContext.Store_Menu.Where(m => (m.Menu.StartTimeService <= vietnamTime.TimeOfDay && m.Menu.EndTimeService > vietnamTime.TimeOfDay) // Khoảng thời gian từ 13:00:00 đến 23:59:59
                                                                     || ((m.Menu.StartTimeService <= vietnamTime.TimeOfDay.Add(new TimeSpan(5, 0, 0))) && (m.Menu.EndTimeService > vietnamTime.TimeOfDay.Add(new TimeSpan(5, 0, 0)))) // Khoảng thời gian từ 00:00:00 đến 02:00:00
                                                                     && m.ApplyDate == currentDayOfWeek.ToString() // chỗ này là thứ mấy
                                                                     && m.Priority == true
                                                                     && m.StoreId == stationExist.StoreID)
                                                                     .SingleOrDefaultAsync();*/
            if (storeMenus == null) {
                if (stationExist == null) {
                    throw new ArgumentNullException(nameof(stationExist), "Station không được phép là null");
                }
                throw new NotFoundException("StoreMenu chưa được tạo, cần phải có storeMenu, hoặc hết giờ hoặt động của cửa hàng");
            }
            var sotrmenu = storeMenus.MenuId;
            var menuExist = await _metroPickUpDbContext.Menu.Where(m => m.Id == sotrmenu && !m.IsDelete).SingleOrDefaultAsync();


            // get MenuProduct với cái Menu của StoreMenu
            var menuProductList = await _metroPickUpDbContext.Menu_Product.Where(s => !s.IsDelete && s.MenuID == storeMenus.MenuId)
                                                        .Join(
                                                            _metroPickUpDbContext.Menu,
                                                            menuProduct => menuProduct.MenuID,
                                                            menu => menu.Id,
                                                            (menuProduct, menu) => new
                                                            {
                                                                MenuProducts = menuProduct,
                                                                Menus = menu
                                                            }
                                                        )
                                                        .Join(
                                                            _metroPickUpDbContext.Product,
                                                            combined => combined.MenuProducts.ProductID,
                                                            product => product.Id,
                                                            (combined, product) => new MenuProductResponse
                                                            {
                                                                Id = combined.MenuProducts.Id,
                                                                MenuID = combined.MenuProducts.MenuID,
                                                                ProductID = combined.MenuProducts.ProductID,
                                                                PriceOfProductBelongToTimeService = combined.MenuProducts.PriceOfProductBelongToTimeService,
                                                                Created = combined.MenuProducts.Created,

                                                                ProductData = _mapper.Map<ProductData>(product),
                                                                StoreData = _mapper.Map<StoreData>(storeExist)
                                                            }
                                                        ).ToListAsync();
            var data = new MenuProductResponseData
            {
                MenuData = _mapper.Map<MenuResponse>(menuExist),
                MenuProductData = menuProductList
            };

            return data;
        }
    }
}
