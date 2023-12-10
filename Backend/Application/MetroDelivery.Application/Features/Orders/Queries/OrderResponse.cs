using MetroDelivery.Application.Features.Customers;
using MetroDelivery.Application.Features.OrderDetails.Queries;
using MetroDelivery.Application.Features.Routes.Queries;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Orders.Queries
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        //Customer
        public string ApplicationUserID { get; set; }

        // Trip
        public Guid TripId { get; set; }

        //Store
        public Guid StoreId { get; set; }
        
        // order
        public string? OrderTokenQR { get; set; }
        public double? TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? Created { get; set; }

        public CustomerResponse? CustomerData { get; set; }
        public TripData? TripData { get; set; }
        public StoreData? StoreData { get; set; }
    }

    public class OrderResponseMessage
    {
        public Guid OrderId { get; set; }
        public Guid OrderDetailId { get; set; }
    }

    public class TripData
    {
        public Guid Id { get; set; }
        public string TripName { get; set; }

        public RouteResponse? RouteResponse { get; set; }
    }



    #region
    public class OrderRequest
    {
        public Guid OrderId { get; set; }
        //Customer
        public string ApplicationUserID { get; set; }
        // Trip
        public Guid TripId { get; set; }
        //Store
        public Guid StoreId { get; set; }

        // order
        public string? OrderTokenQR { get; set; }
        public double? TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? Created { get; set; }

        public CustomerResponse? CustomerData { get; set; }
        public TripData? TripData { get; set; }
        public StoreData? StoreData { get; set; }
        public List<OrderDetailRequest> OrderDetailRequest { get; set; }
        public StationData? StationData { get; set; }
    }

    public class OrderDetailRequest
    {
        public Guid OrderDetailId { get; set; }
        public int? Quanity { get; set; }
        public double? Price { get; set; }

        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public DateTime Created { get; set; }

        public ProductResponseData? ProductResponseData { get; set; }
    }

    public class ProductResponseData
    {
        public string ProductName { get; set; }
        public string Image { get; set; }
    }

    #endregion
}
