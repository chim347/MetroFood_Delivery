using MetroDelivery.Application.Features.PaymentMethods.Queries;
using MetroDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Withdraws.Queries
{
    public class WithdrawResponse
    {
        public Guid Id { get; set; }

        public string ApplicationUserID { get; set; }
        public Guid PaymentMethodID { get; set; }
        public double? Balance { get; set; }
        public double? Deposit { get; set; }
        public DateTime? Created { get; set; }

        // relationship
        public CustomerData? CustomerData { get; set; }
        public PaymentMethodResponse? PaymentMethodData { get; set; }
    }

    public class CustomerData
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? Wallet { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
    }
}
