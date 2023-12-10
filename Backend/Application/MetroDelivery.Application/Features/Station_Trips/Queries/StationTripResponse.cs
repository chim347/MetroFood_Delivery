using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Application.Features.Trips.Queries;
using MetroDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Station_Trips.Queries
{
    public class StationTripResponse
    {
        public Guid Id { get; set; }
        public Guid TripID { get; set; }
        public Guid StationID { get; set; }
        public DateTime? Arrived { get; set; }

        
        public TripResponse? TripData { get; set; }
        public StationData? StationData { get; set; }
    }
}
