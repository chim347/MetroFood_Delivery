using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Products.Queries.GetAllProduct
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, List<ProductResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListProductQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductResponse>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            /*var productList = await _metroPickUpDbContext.Products.Where(p => !p.IsDelete).ToListAsync();
            if(!productList.Any()) {
                throw new NotFoundException("Không có bất kì product nào");
            }*/

            var product = await _metroPickUpDbContext.Product.Where(p => !p.IsDelete)
                                                    .Join(
                                                        _metroPickUpDbContext.Categories,
                                                        products => products.CategoryID,
                                                        category => category.Id,
                                                        (products, category) => new ProductResponse
                                                        {
                                                            Id = products.Id,
                                                            ProductName = products.ProductName,
                                                            ProductDescription = products.ProductDescription,
                                                            Image = products.Image,
                                                            Price = products.Price,
                                                            Created = products.Created,
                                                            CategoryID = products.CategoryID,
                                                            CategoryData = category,
                                                        }
                                                    )
                                                    .ToListAsync();  

            /*var data = _mapper.Map<List<ProductResponse>>(productList);*/

            return product;
        }
    }
}
