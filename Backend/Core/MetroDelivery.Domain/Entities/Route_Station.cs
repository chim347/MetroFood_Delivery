using MetroDelivery.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDelivery.Domain.Entities
{
    public class Route_Station : BaseAuditableEntity
    {
        [ForeignKey("Route")]
        public Guid RouteID { get; set; }
        [ForeignKey("Station")]
        public Guid StationID {  get; set; }
        public int? Index { get; set; }
        public TimeSpan? Duration { get; set; }
        public TimeSpan? StopTime { get; set; }

        //relationship
        public virtual Route Route { get; set; }
        public virtual Station Station { get; set; }
    }
}
