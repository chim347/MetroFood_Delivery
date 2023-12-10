using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Station_Trips.Commands.CreateStationTrip
{
    public class CreateStationTripCommand : IRequest<Guid>
    {
        public string TripName { get; set; }
        public DateTime TripStartTime { get; set; }
        public DateTime TripEndTime { get; set; }

        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        // tuyến Suối tiên -> bến thành có 3 trạm. thì 1 con tàu đi qua 3 trạm, và có arrvied là thời gian đến từng trạm
        public List<StationDataInStationTrip> StationList { get; set; }

    }

    public class StationDataInStationTrip
    {
        public string StationId { get; set; }
        public DateTime Arrived { get; set; } // thời gian đến cái trạm
    }
}
