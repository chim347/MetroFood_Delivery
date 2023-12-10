using MetroDelivery.Domain.Common;

namespace MetroDelivery.Domain.Entities
{
    public class Route : BaseAuditableEntity
    {
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }

        //relationship
        public IList<Trip> Trip { get; private set; }
        public IList<Route_Station> Route_Stations { get; private set; }

    }
}
