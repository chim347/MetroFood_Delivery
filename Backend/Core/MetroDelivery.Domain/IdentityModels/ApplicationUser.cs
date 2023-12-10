using MetroDelivery.Domain.Common;
using MetroDelivery.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Domain.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public double? Wallet { get ; set; }
        public DateTime? Created { get; set; }

        public Guid? StoreId { get; set; }
        // relationship

        public IList<Order> Orders { get; private set; }
        public IList<WithDraw> WithDraws { get; private set; }
    }
}
