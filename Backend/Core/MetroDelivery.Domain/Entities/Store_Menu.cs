using MetroDelivery.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Domain.Entities
{
    public class Store_Menu : BaseAuditableEntity
    {
        [ForeignKey("Store")]
        public Guid StoreId {  get; set; }
        [ForeignKey("Menu")]
        public Guid MenuId { get; set; }
        public string? ApplyDate { get; set; }
        public bool Priority { get; set; }

        //relationship
        public virtual Store Store { get; private set; }
        public virtual Menu Menu { get; private set; }
    }
}
