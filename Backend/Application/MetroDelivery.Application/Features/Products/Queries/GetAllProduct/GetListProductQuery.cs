using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Products.Queries.GetAllProduct
{
    public class GetListProductQuery : IRequest<List<ProductResponse>>
    {

    }
}
