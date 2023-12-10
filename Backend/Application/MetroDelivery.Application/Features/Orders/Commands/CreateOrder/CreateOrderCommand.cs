using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Orders.Queries;
using MetroDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<MetroPickUpResponse>
    {
        //Customer
        public string ApplicationUserID { get; set; }

        // Trip
        public string TripId { get; set; }

        //Store
        public string StoreId { get; set; }

        
        /*public double? TotalPrice { get; set; }*/

        // 1 list product được chọn từ MenuProduct
        public List<ProductRequest> Products { get; set; }
    }

    public class ProductRequest
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public double PriceOfProductBelongToTimeService { get; set; }
    }

}
