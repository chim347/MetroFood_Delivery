using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Routes.Queries.GetAllRoute
{
    public class GetListRouteQuery : IRequest<List<RouteResponse>>
    {
    }
}
