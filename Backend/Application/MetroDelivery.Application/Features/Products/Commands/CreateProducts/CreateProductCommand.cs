using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Routes.Commands.CreateRoute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Products.Commands.CreateProducts
{
    public class CreateProductCommand : IRequest<MetroPickUpResponse>
    {
        public string CategoryID { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
    }
}
