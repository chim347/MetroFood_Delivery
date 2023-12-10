using MetroDelivery.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MetroDelivery.Domain.Entities
{
    public class Category : BaseAuditableEntity
    {
        public string CategoryName { get;set; }
    }
}
