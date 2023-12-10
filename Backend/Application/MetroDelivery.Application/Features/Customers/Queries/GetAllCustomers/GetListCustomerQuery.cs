using MediatR;
using MetroDelivery.Application.Features.Staff.Queries;

namespace MetroDelivery.Application.Features.Customers.Queries.GetAllCustomers
{
    public record GetListCustomerQuery : IRequest<List<CustomerRole>>
    {
    }
}
