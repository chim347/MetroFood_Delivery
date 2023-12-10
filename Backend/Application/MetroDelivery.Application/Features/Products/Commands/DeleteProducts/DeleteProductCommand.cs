using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Products.Commands.DeleteProducts
{
    public class DeleteProductCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
    }
}
