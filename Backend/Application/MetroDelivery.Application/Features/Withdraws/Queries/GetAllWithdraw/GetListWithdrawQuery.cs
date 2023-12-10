using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.PaymentMethods.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Withdraws.Queries.GetAllWithdraw
{
    public class GetListWithdrawQuery : IRequest<List<WithdrawResponse>>
    {
    }

    public class GetListWithdrawQueryHandler : IRequestHandler<GetListWithdrawQuery, List<WithdrawResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListWithdrawQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<WithdrawResponse>> Handle(GetListWithdrawQuery request, CancellationToken cancellationToken)
        {
            var listWithdraw = await _metroPickUpDbContext.WithDraw.Where(w => !w.IsDelete)
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
                                                                ).ToListAsync();

            return listWithdraw;
        }
    }
}
