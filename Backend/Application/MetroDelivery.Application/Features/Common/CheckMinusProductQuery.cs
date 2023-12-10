using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Common
{
    public class CheckMinusProductQuery : IRequest<MetroPickUpResponse>
    {
        public string? ProductId { get; set; }
    }

    public class CheckMinusProductQueryHandler : IRequestHandler<CheckMinusProductQuery, MetroPickUpResponse>
    {
        private readonly IProductRepository _customerRepository;

        public CheckMinusProductQueryHandler(IProductRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<MetroPickUpResponse> Handle(CheckMinusProductQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
