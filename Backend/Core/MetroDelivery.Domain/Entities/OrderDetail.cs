using MetroDelivery.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDelivery.Domain.Entities
{
    public class OrderDetail : BaseAuditableEntity
    {
        [ForeignKey("Order")]
        public Guid OrderID { get; set; }
        [ForeignKey("Product")]
        public Guid ProductID { get; set; }
        public int? Quanity { get; set; }
        public double? Price { get; set; }

        // relationship
        public virtual Order Order { get; private set; }
        public virtual Product Products { get; private set; }
    }
}
