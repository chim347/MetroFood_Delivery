using MediatR;
using MetroDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.OrderDetails.Queries
{
    public class OrderDetailResponse
    {
        public Guid OrderDetailId { get; set; }
        public int? Quanity { get; set; }
        public double? Price { get; set; }

        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public DateTime Created { get; set; }

        /*public Order? OrderData { get; set; }
        public Product? ProductData { get; set; }*/

        public OrderData? OrderData { get; set; }
        public ProductData? ProductData { get; set; }

    }

    public class OrderData
    {
        public string ApplicationUserID { get; set; }
        public Guid TripID { get; set; }
        public Guid StoreID { get; set; }
        public double? TotalPrice { get; set; }
        public string? OrderTokenQR { get; set; }
        public DateTime Created { get; set; }
    }

    public class ProductData
    {
        public Guid CategoryID { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? Image { get; set; }
        public double? Price { get; set; }
        public DateTime Created { get; set; }
    }
}
