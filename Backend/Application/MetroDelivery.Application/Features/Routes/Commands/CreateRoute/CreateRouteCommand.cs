using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Trips.Commands.CreateTrip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Routes.Commands.CreateRoute
{
    public class CreateRouteCommand : IRequest<Guid>
    {
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
    }
}
