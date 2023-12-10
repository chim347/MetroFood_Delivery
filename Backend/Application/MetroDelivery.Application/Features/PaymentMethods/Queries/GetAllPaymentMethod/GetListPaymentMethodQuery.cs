using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.PaymentMethods.Queries.GetAllPaymentMethod
{
    public class GetListPaymentMethodQuery : IRequest<List<PaymentMethodResponse>>
    {

    }
}
