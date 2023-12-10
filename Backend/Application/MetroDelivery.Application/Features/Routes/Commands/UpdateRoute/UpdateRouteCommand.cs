using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Routes.Commands.CreateRoute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Routes.Commands.UpdateRoute
{
    public class UpdateRouteCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
    }
}
