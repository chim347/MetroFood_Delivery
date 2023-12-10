using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.PaymentMethods.Queries.GetByIdPaymentMethod
{
    public class GetByIdPaymentMethodQuery : IRequest<PaymentMethodResponse>
    {
        public string Id { get; set; }
    }

    public class GetByIdPaymentMethodQueryHandler : IRequestHandler<GetByIdPaymentMethodQuery, PaymentMethodResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetByIdPaymentMethodQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<PaymentMethodResponse> Handle(GetByIdPaymentMethodQuery request, CancellationToken cancellationToken)
        {
            var paymentMethodExist = await _metroPickUpDbContext.PaymentMethod.Where(p => p.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();

            if (paymentMethodExist == null) {
                throw new NotFoundException("Không có paymentMethod nào hết");
            }
            if (paymentMethodExist.IsDelete == true) {
                throw new NotFoundException("paymentMethod đã bị xóa");
            }

            var data = _mapper.Map<PaymentMethodResponse>(paymentMethodExist);

            return data;
        }
    }
}
