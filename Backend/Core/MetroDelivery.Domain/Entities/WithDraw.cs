using MetroDelivery.Domain.Common;
using MetroDelivery.Domain.IdentityModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDelivery.Domain.Entities
{
    public class WithDraw : BaseAuditableEntity
    {
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        [ForeignKey("PaymentMethod")]
        public Guid PaymentMethodID { get; set; }
        public double? Balance { get; set; }
        public double? Deposit { get; set; }
        public DateTime? CreateTimeOfWithdraw { get; set; }

        // relationship
        public virtual ApplicationUser ApplicationUser { get; private set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
