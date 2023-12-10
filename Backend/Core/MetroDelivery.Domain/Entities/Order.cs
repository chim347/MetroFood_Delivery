using MetroDelivery.Domain.Common;
using MetroDelivery.Domain.IdentityModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDelivery.Domain.Entities
{
    public class Order : BaseAuditableEntity
    {
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        [ForeignKey("Trip")]
        public Guid TripID { get; set; }
        [ForeignKey("Store")]
        public Guid StoreID { get; set; }
        public int? OrderStatus { get; set; }

        public double? TotalPrice { get; set; }
        public string? OrderTokenQR { get; set; }

        //relationship
        public virtual ApplicationUser ApplicationUser { get; private set; }
        public virtual Trip Trip { get; private set; }
        public virtual Store Store { get; private set; }
        
        public IList<OrderDetail> OrderDetail { get; private set; }
    }
}
