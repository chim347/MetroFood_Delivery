using MetroDelivery.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDelivery.Domain.Entities
{
    public class Station_Trip : BaseAuditableEntity
    {
        [ForeignKey("Trip")]
        public Guid TripID { get; set; }
        [ForeignKey("Station")]
        public Guid StationID { get; set; }
        public DateTime Arrived { get; set; }

        //relationship
        public virtual Trip Trip { get; set; }
        public virtual Station Station { get; set; }
    }
}
