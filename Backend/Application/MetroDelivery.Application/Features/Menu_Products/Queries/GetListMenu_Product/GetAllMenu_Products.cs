using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Menu_Products.Queries.GetListMenu_Product
{
    public class GetAllMenu_Products : IRequest<List<MenuProductResponse>>
    {
    }
}
