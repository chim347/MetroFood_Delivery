using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Trips.Queries
{
    public class TripResponse
    {
        public Guid Id { get; set; }
        public string TripName { get; set; }
        public DateTime TripStartTime { get; set; }
        public DateTime TripEndTime { get; set; }
        public Guid RouteId { get; set; }

        public RouteData? RouteData { get; set; }
    }

    public class RouteData
    {
        public Guid Id { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
    }

}
