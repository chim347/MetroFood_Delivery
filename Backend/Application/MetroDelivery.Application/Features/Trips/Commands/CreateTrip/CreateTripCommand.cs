using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Trips.Commands.CreateTrip
{
    public class CreateTripCommand : IRequest<Guid>
    {
        public string TripName { get; set; }
        public DateTime TripStartTime { get; set; }
        public DateTime TripEndTime { get; set; }
        public Guid RouteId { get; set; }

    }
}
