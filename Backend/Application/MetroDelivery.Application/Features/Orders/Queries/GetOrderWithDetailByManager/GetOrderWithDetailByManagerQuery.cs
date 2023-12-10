using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Customers;
using MetroDelivery.Application.Features.Routes.Queries;
using MetroDelivery.Application.Features.Stations.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Orders.Queries.GetOrderWithDetailByManager
{
    public class GetOrderWithDetailByManagerQuery : IRequest<List<OrderRequest>>
    {
        public string StoreId { get; set; }
    }

    public class GetOrderWithDetailByManagerQueryHandler : IRequestHandler<GetOrderWithDetailByManagerQuery, List<OrderRequest>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetOrderWithDetailByManagerQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderRequest>> Handle(GetOrderWithDetailByManagerQuery request, CancellationToken cancellationToken)
        {
            var order = await _metroPickUpDbContext.Order
            .Where(o => !o.IsDelete && o.StoreID == Guid.Parse(request.StoreId))
            .Join(
                _metroPickUpDbContext.ApplicationUsers,
                orders => orders.ApplicationUserID,
                applicationUser => applicationUser.Id,
                (orders, applicationUser) => new
                {
                    Orders = orders,
                    ApplicationUser = applicationUser
                }
            )
            .Join(
                _metroPickUpDbContext.Trip,
                orderCustomer => orderCustomer.Orders.TripID,
                trip => trip.Id,
                (orderCutomer, trip) => new { OrderCustomer = orderCutomer, Trips = trip }
            )
            .Join(
                _metroPickUpDbContext.Store,
                orderCutomerTrip => orderCutomerTrip.OrderCustomer.Orders.StoreID,
                store => store.Id,
                (orderCutomerTrip, store) => new
                {
                    OrderId = orderCutomerTrip.OrderCustomer.Orders.Id,
                    orderCutomerTrip.OrderCustomer.Orders.TotalPrice,
                    orderCutomerTrip.OrderCustomer.Orders.OrderTokenQR,
                    orderCutomerTrip.OrderCustomer.Orders.ApplicationUserID,
                    TripId = orderCutomerTrip.OrderCustomer.Orders.TripID,
                    StoreId = orderCutomerTrip.OrderCustomer.Orders.StoreID,
                    orderCutomerTrip.OrderCustomer.Orders.OrderStatus,
                    orderCutomerTrip.OrderCustomer.Orders.Created,
                    CustomerData = _mapper.Map<CustomerResponse>(orderCutomerTrip.OrderCustomer.ApplicationUser),
                    TripData = new TripData
                    {
                        Id = orderCutomerTrip.Trips.Id,
                        TripName = orderCutomerTrip.Trips.TripName,

                        RouteResponse = _metroPickUpDbContext.Trip.Where(t => t.Id == orderCutomerTrip.Trips.Id)
                                        .Join(
                                            _metroPickUpDbContext.Route,
                                            trip => trip.RouteId,
                                            route => route.Id,
                                            (trip, route) => _mapper.Map<RouteResponse>(route)
                                        ).FirstOrDefault(),
                    },
                    StoreData = _mapper.Map<StoreData>(store),
                    StationData = _mapper.Map<StationData>(_metroPickUpDbContext.Station.Where(s => s.StoreID == store.Id).SingleOrDefault())
                }
            )
            .OrderByDescending(o => o.Created)
            .ToListAsync();


            var materializedOrder = order
                .Select(orderItem => new OrderRequest
                {
                    OrderId = orderItem.OrderId,
                    TotalPrice = orderItem.TotalPrice,
                    OrderTokenQR = orderItem.OrderTokenQR,
                    ApplicationUserID = orderItem.ApplicationUserID,
                    TripId = orderItem.TripId,
                    StoreId = orderItem.StoreId,
                    OrderStatus = GetOrderStatusName(orderItem.OrderStatus),
                    Created = orderItem.Created,
                    CustomerData = orderItem.CustomerData,
                    TripData = new TripData
                    {
                        Id = orderItem.TripData.Id,
                        TripName = orderItem.TripData.TripName,

                        RouteResponse = orderItem.TripData.RouteResponse,
                    },
                    StoreData = orderItem.StoreData,
                    StationData = orderItem.StationData,
                    OrderDetailRequest = GetOrderDetailData(orderItem.OrderId)
                })
                .ToList();

            return materializedOrder;
        }

        private List<OrderDetailRequest> GetOrderDetailData(Guid orderId)
        {
            var orderDetailExist = _metroPickUpDbContext.OrderDetail
                .Where(o => !o.IsDelete && o.OrderID == orderId)
                .Join(
                    _metroPickUpDbContext.Product,
                    orderDetail => orderDetail.ProductID,
                    product => product.Id,
                    (orderDetail, product) => new OrderDetailRequest
                    {
                        OrderDetailId = orderDetail.Id,
                        Quanity = orderDetail.Quanity,
                        Price = orderDetail.Price,
                        ProductID = orderDetail.ProductID,
                        OrderID = orderDetail.OrderID,
                        Created = orderDetail.Created,

                        ProductResponseData = _mapper.Map<ProductResponseData>(product)
                    }
                )
                .ToList();

            return orderDetailExist;
        }

        private string GetOrderStatusName(int? orderStatus)
        {
            switch (orderStatus) {
                case 0:
                    return "Pending";
                case 1:
                    return "Accepted";
                case 2:
                    return "Finished";
                case 3:
                    return "Cancel";
                default:
                    return "Unknown";
            }
        }
    }
}
