using MetroDelivery.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDelivery.Domain.Entities
{
    public class Menu_Product : BaseAuditableEntity
    {
        [ForeignKey("Menu")]
        public Guid MenuID { get; set; }
        [ForeignKey("Product")]
        public Guid ProductID {  get; set; }

        public double? PriceOfProductBelongToTimeService { get; set; }

        // relationship
        public virtual Menu Menu { get; set; }
        public virtual Product Products { get; set; }
    }
}
