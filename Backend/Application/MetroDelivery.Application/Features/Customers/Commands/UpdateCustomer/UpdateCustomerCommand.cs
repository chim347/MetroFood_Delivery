using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public double Wallet { get; set; }
    }
}
