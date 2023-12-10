using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Trips.Commands.DeleteTrip
{
    public class DeleteTripCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
    }
}
