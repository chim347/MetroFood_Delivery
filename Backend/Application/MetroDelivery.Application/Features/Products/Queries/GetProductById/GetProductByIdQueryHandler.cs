using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            /*var checkProductId = await _metroPickUpDbContext.Products.Where(p => p.Id == request.Id).SingleOrDefaultAsync();
            if (checkProductId == null) {
                throw new NotFoundException($"Không tìm thấy product {request.Id}");
            }
            if (checkProductId.IsDelete == true) {
                throw new NotFoundException($"{request.Id} đã bị xóa khỏi product");
            }*/

            var product = await _metroPickUpDbContext.Product.Where(p => !p.IsDelete && p.Id == Guid.Parse(request.Id))
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
                                                    .SingleOrDefaultAsync();
            if (product == null) {
                throw new NotFoundException($"Không tìm thấy product {request.Id}");
            }
            /*var data = _mapper.Map<ProductResponse>(checkProductId);*/

            return product;
        }
    }
}
