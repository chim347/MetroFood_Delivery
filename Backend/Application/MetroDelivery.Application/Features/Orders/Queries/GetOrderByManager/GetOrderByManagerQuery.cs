using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Customers;
using MetroDelivery.Application.Features.Stations.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Orders.Queries.GetOrderByManager
{
    public class GetOrderByManagerQuery : IRequest<List<OrderResponse>>
    {
        public string StoreId { get; set; }
    }

    public class GetOrderByManagerQueryHandler : IRequestHandler<GetOrderByManagerQuery, List<OrderResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetOrderByManagerQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderResponse>> Handle(GetOrderByManagerQuery request, CancellationToken cancellationToken)
        {
            var order = await _metroPickUpDbContext.Order.Where(o => !o.IsDelete && o.StoreID == Guid.Parse(request.StoreId))
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
                                                                (orderCutomerTrip, store) => new OrderResponse
                                                                {
                                                                    OrderId = orderCutomerTrip.OrderCustomer.Orders.Id,
                                                                    TotalPrice = orderCutomerTrip.OrderCustomer.Orders.TotalPrice,
                                                                    OrderTokenQR = orderCutomerTrip.OrderCustomer.Orders.OrderTokenQR,

                                                                    ApplicationUserID = orderCutomerTrip.OrderCustomer.Orders.ApplicationUserID,
                                                                    TripId = orderCutomerTrip.OrderCustomer.Orders.TripID,
                                                                    StoreId = orderCutomerTrip.OrderCustomer.Orders.StoreID,
                                                                    OrderStatus = GetOrderStatusName(orderCutomerTrip.OrderCustomer.Orders.OrderStatus),
                                                                    Created = orderCutomerTrip.OrderCustomer.Orders.Created,

                                                                    CustomerData = _mapper.Map<CustomerResponse>(orderCutomerTrip.OrderCustomer.ApplicationUser),
                                                                    TripData = _mapper.Map<TripData>(orderCutomerTrip.Trips),
                                                                    StoreData = _mapper.Map<StoreData>(store)
                                                                }
                                                            )
                                                            .OrderByDescending(o => o.Created)
                                                            .ToListAsync();
            /*if (order == null) {
                throw new NotFoundException("Order is not existed");
            }*/

            return order;
        }

        private static string GetOrderStatusName(int? orderStatus)
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
