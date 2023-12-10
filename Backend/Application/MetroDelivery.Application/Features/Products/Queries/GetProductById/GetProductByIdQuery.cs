using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public string Id { get; set; }
    }
}
