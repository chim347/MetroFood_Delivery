using MetroDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stations.Queries
{
    public class StationResponse
    {
        public StationData? StationData { get; set; }
        public StoreData? StoreData { get; set; }
    }

    public class StationData
    {
        public Guid Id { get; set; }
        public Guid StoreID { get; set; }
        public string? StationName { get; set; }
        public DateTime Created { get; set; }
    }

    public class StoreData
    {
        public Guid Id { get; set; }
        public string? StoreName { get; set; }
        public string? StoreLocation { get; set; }
        public TimeSpan StoreOpenTime { get; set; }
        public TimeSpan StoreCloseTime { get; set; }
        public DateTime Created { get; set; }
    }
}
