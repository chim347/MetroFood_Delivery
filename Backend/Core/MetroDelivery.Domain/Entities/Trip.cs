using MetroDelivery.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDelivery.Domain.Entities
{
    public class Trip : BaseAuditableEntity
    {
        [ForeignKey("Route")]
        public Guid RouteId { get; set; }
        public string TripName { get; set; }
        public DateTime TripStartTime { get; set; }
        public DateTime TripEndTime { get; set;}
        
        //relationship
        public IList<Order> Order { get; set; }
        public IList<Station_Trip> Station_Trip { get; private set; }
        public virtual Route Route { get; private set; }
    }
}
