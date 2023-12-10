using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.OrderDetails.Queries;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Menu_Products.Commands.CreateMenuProduct
{
    public class CreateMenuProductCommand : IRequest<MetroPickUpResponse>
    {
        /*public string MenuName { get; set; }
        public TimeSpan StartTimeService { get; set; }
        public TimeSpan EndTimeService { get; set; }*/
        public string MenuId { get; set; }

        public List<ProductList> ProductData { get; init; }
    }
    public class ProductList
    {
        public string ProductID { get; init; }
        public double? PriceOfProductBelongToTimeService { get; set; }
    }

    public class CreateMenuProductCommandHandler : IRequestHandler<CreateMenuProductCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public CreateMenuProductCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(CreateMenuProductCommand request, CancellationToken cancellationToken)
        {
            var productIs = request.ProductData.Select(s => Guid.Parse(s.ProductID)).ToList();
            var productExist = await _metroPickUpDbContext.Product.Where(p => productIs.Contains(p.Id) && !p.IsDelete).ToListAsync();

            // tạo menu
           /* var checkMenuExist = await _metroPickUpDbContext.Menu.Where(m => m.MenuName == request.MenuName && m.StartTimeService == request.StartTimeService && m.EndTimeService == request.EndTimeService && !m.IsDelete).SingleOrDefaultAsync();
            if (checkMenuExist != null) {
                throw new NotFoundException("MenuName này đã tạo trong Menu_Product rồi");
            }
            var menu = new Menu
            {
                MenuName = request.MenuName,
                StartTimeService = request.StartTimeService,
                EndTimeService = request.EndTimeService,
            };*//*

            _metroPickUpDbContext.Menu.Add(menu);
            await _metroPickUpDbContext.SaveChangesAsync();*/

            // tạo menu_product
            if (productExist.Count() == 0) {
                throw new NotFoundException($"Không tìm thấy Product nào!");
            }

            foreach ( var productData in request.ProductData) {
                var product = productExist.FirstOrDefault(p => p.Id == Guid.Parse(productData.ProductID));
                if(product == null) {
                    throw new NotFoundException($"Không tìm thấy product {product} này!");
                }
                var productMenuExist = await _metroPickUpDbContext.Menu_Product.Where(m => m.ProductID == product.Id && m.MenuID == Guid.Parse(request.MenuId) && !m.IsDelete).SingleOrDefaultAsync();
                if (productMenuExist != null) {
                    throw new NotFoundException($"{product.ProductName}: already existed !!");
                }

                var entityMenuProduct = new Menu_Product();
                entityMenuProduct.MenuID = Guid.Parse(request.MenuId);
                entityMenuProduct.ProductID = product.Id;
                entityMenuProduct.PriceOfProductBelongToTimeService = productData.PriceOfProductBelongToTimeService;
            
                _metroPickUpDbContext.Menu_Product.Add(entityMenuProduct);
            }

            await _metroPickUpDbContext.SaveChangesAsync();
            return new MetroPickUpResponse
            {
                Message = "Create Menu Product Successfully"
            };
        }
    }
}
