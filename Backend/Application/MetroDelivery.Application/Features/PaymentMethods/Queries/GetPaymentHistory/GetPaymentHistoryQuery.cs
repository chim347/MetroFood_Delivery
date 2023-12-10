using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Models.VnPay;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.PaymentMethods.Queries.GetPaymentHistory
{
    public class GetPaymentHistoryQuery : IRequest<PaymentResponse>
    {
        public string OrderId { get; set; } 
          
    }

    public class GetPaymentHistoryQueryHandler : IRequestHandler<GetPaymentHistoryQuery, PaymentResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetPaymentHistoryQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<PaymentResponse> Handle(GetPaymentHistoryQuery request, CancellationToken cancellationToken)
        {
            var history = await _metroPickUpDbContext.PaymentHistory.Where(p => p.OrderId == request.OrderId).SingleOrDefaultAsync();

            var data = _mapper.Map<PaymentResponse>(history);

            return data;
        }
    }
}
