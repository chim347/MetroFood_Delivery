using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.PaymentMethods.Queries;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Withdraws.Queries.GetByIdWithdraw
{
    public class GetByIdWithdrawQuery : IRequest<WithdrawResponse>
    {
        public string Id { get; set; }
    }

    public class GetByIdWithdrawQueryHandler : IRequestHandler<GetByIdWithdrawQuery, WithdrawResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetByIdWithdrawQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<WithdrawResponse> Handle(GetByIdWithdrawQuery request, CancellationToken cancellationToken)
        {
            var withdraw = await _metroPickUpDbContext.WithDraw.Where(w => !w.IsDelete && w.Id == Guid.Parse(request.Id))
                                                                 .Join(
                                                                     _metroPickUpDbContext.ApplicationUsers,
                                                                     withdraws => withdraws.ApplicationUserID,
                                                                     applicationUser => applicationUser.Id,
                                                                     (withdraws, applicationUser) => new
                                                                     {
                                                                         WithDraws = withdraws,
                                                                         ApplicationUsers = applicationUser
                                                                     }
                                                                 )
                                                                 .Join(
                                                                     _metroPickUpDbContext.PaymentMethod,
                                                                     combined => combined.WithDraws.PaymentMethodID,
                                                                     payment => payment.Id,
                                                                     (combined, payment) => new WithdrawResponse
                                                                     {
                                                                         Id = combined.WithDraws.Id,
                                                                         Balance = combined.WithDraws.Balance,
                                                                         Deposit = combined.WithDraws.Deposit,
                                                                         ApplicationUserID = combined.WithDraws.ApplicationUserID,
                                                                         PaymentMethodID = combined.WithDraws.PaymentMethodID,
                                                                         Created = combined.WithDraws.Created,

                                                                         CustomerData = _mapper.Map<CustomerData>(combined.ApplicationUsers),
                                                                         PaymentMethodData = _mapper.Map<PaymentMethodResponse>(payment)
                                                                     }
                                                                 ).SingleOrDefaultAsync();
            if (withdraw == null) {
                throw new NotFoundException("WithdraId không tồn tại");
            }

            return withdraw;
        }
    }
}
