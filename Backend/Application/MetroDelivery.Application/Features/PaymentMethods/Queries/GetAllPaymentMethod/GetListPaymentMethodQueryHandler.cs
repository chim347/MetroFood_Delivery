using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.PaymentMethods.Queries.GetAllPaymentMethod
{
    public class GetListPaymentMethodQueryHandler : IRequestHandler<GetListPaymentMethodQuery, List<PaymentMethodResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListPaymentMethodQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<PaymentMethodResponse>> Handle(GetListPaymentMethodQuery request, CancellationToken cancellationToken)
        {
            var listPayment = await _metroPickUpDbContext.PaymentMethod.Where(p => !p.IsDelete).ToListAsync();
            if(listPayment == null){
                throw new NotFoundException("Không có paymentMethod nào hết");
            }

            var data = _mapper.Map<List<PaymentMethodResponse>>(listPayment);

            return data;
        }
    }
}
