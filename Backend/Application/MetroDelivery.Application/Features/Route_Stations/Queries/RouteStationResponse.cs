using MetroDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Route_Stations.Queries
{
    public class RouteStationResponse
    {
        public Guid Id { get; set; }
        [ForeignKey("Route")]
        public Guid RouteID { get; set; }
        [ForeignKey("Station")]
        public Guid StationID { get; set; }
        public int? Index { get; set; }
        public TimeSpan? Duration { get; set; }
        public TimeSpan? StopTime { get; set; }
        public DateTime Created { get; set; }


        public Route? RouteData { get; set; }
        public Station? StationData { get; set; }
    }
}
