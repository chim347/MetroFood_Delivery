using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.PaymentMethods.Queries
{
    public class PaymentMethodResponse
    {
        public Guid Id { get; set; }
        public string PaymentMethodName { get; set; }
    }
}
