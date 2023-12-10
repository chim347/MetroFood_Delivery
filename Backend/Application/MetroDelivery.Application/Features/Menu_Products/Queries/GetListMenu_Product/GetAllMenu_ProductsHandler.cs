using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Application.Features.Menu_Products;
using MetroDelivery.Application.Features.Menus.Queries;
using MetroDelivery.Application.Features.OrderDetails.Queries;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Application.Features.Store_Menus.Queries;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Menu_Products.Queries.GetListMenu_Product
{
    public class GetAllMenu_ProductsHandler : IRequestHandler<GetAllMenu_Products, List<MenuProductResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetAllMenu_ProductsHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }
        public async Task<List<MenuProductResponse>> Handle(GetAllMenu_Products request, CancellationToken cancellationToken)
        {
            var menuProductList = await _metroPickUpDbContext.Menu_Product.Where(s => !s.IsDelete)
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

                                                                        MenuData = _mapper.Map<MenuResponse>(combined.Menus),
                                                                        ProductData = _mapper.Map<ProductData>(product)
                                                                    }
                                                                ).ToListAsync();
            return menuProductList;
        }
    }
}
