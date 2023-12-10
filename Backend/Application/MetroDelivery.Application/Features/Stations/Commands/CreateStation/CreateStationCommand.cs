using MediatR;
using MetroDelivery.Application.Features.Trips.Commands.CreateTrip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stations.Commands.CreateStation
{
    public class CreateStationCommand : IRequest<Guid>
    {
        public Guid StoreID { get; set; }
        public string StationName { get; set; }
    }
}
