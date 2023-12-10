using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Routes.Commands.DeleteRoute
{
    public class DeleteRouteCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
    }
}
