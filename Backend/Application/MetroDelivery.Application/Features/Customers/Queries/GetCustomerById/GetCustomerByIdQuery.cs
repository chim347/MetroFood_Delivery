using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Customers.Queries.GetCustomerById
{
    public record GetCustomerByIdQuery(string id) : IRequest<CustomerRole>;
}
