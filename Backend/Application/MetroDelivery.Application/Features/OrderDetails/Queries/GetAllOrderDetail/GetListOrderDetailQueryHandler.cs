using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.OrderDetails.Queries.GetAllOrderDetail
{
    public class GetListOrderDetailQueryHandler : IRequestHandler<GetListOrderDetailQuery, List<OrderDetailResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListOrderDetailQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailResponse>> Handle(GetListOrderDetailQuery request, CancellationToken cancellationToken)
        {
            /*var listOrderDetail = await _metroPickUpDbContext.OrderDetails.Where(o => !o.IsDelete)
                                                                        .Join(
                                                                            _metroPickUpDbContext.Orders,
                                                                            orderDetail => orderDetail.OrderID,
                                                                            order => order.Id,
                                                                            (orderDetail, order) => new
                                                                            {
                                                                                OrderDetails = orderDetail,
                                                                                Orders = order
                                                                            }
                                                                        )
                                                                        .Join(
                                                                            _metroPickUpDbContext.Products,
                                                                            combined => combined.OrderDetails.ProductID,
                                                                            product => product.Id,
                                                                            (combined, product) => new OrderDetailResponse
                                                                            {
                                                                                OrderDetailId = combined.OrderDetails.Id,
                                                                                Quanity = combined.OrderDetails.Quanity,    
                                                                                Price = combined.OrderDetails.Price,
                                                                                ProductID = combined.OrderDetails.ProductID,
                                                                                OrderID = combined.OrderDetails.OrderID,
                                                                                Created = combined.OrderDetails.Created,

                                                                                OrderData = combined.Orders,
                                                                                ProductData = product

                                                                            }
                                                                        ).ToListAsync();*/

            
            var listOrderDetail = await _metroPickUpDbContext.OrderDetail.Where(o => !o.IsDelete)
                                                                        .Join(
                                                                            _metroPickUpDbContext.Order,
                                                                            orderDetail => orderDetail.OrderID,
                                                                            order => order.Id,
                                                                            (orderDetail, order) => new
                                                                            {
                                                                                OrderDetails = orderDetail,
                                                                                Orders = order
                                                                            }
                                                                        )
                                                                        .Join(
                                                                            _metroPickUpDbContext.Product,
                                                                            combined => combined.OrderDetails.ProductID,
                                                                            product => product.Id,
                                                                            (combined, product) => new OrderDetailResponse
                                                                            {
                                                                                OrderDetailId = combined.OrderDetails.Id,
                                                                                Quanity = combined.OrderDetails.Quanity,
                                                                                Price = combined.OrderDetails.Price,
                                                                                ProductID = combined.OrderDetails.ProductID,
                                                                                OrderID = combined.OrderDetails.OrderID,
                                                                                Created = combined.OrderDetails.Created,

                                                                                OrderData = _mapper.Map<OrderData>(combined.Orders) ,
                                                                                ProductData = _mapper.Map<ProductData>(product)

                                                                            }
                                                                        ).ToListAsync();

            return listOrderDetail;
        }
    }
}
