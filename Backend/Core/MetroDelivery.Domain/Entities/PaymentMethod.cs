using MetroDelivery.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDelivery.Domain.Entities
{
    public class PaymentMethod : BaseAuditableEntity
    {
        public string PaymentMethodName { get; set; }

        //relationship
        public IList<WithDraw> WithDraw { get; private set; }
    }
}
