using MetroDelivery.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDelivery.Domain.Entities
{
    public class Station : BaseAuditableEntity
    {
        [ForeignKey("Store")]
        public Guid StoreID { get; set; }
        public string StationName { get; set; }

        // relationship 
        public IList<Route_Station> Route_Stations { get; private set;}
        public IList<Station_Trip> Station_Trip { get; private set; }
        public virtual Store Store { get; set; }
    }
}
