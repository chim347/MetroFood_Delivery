using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.PaymentMethods.Queries;
using MetroDelivery.Application.Features.Withdraws.Queries.GetByIdWithdraw;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Withdraws.Queries.GetByUserId
{
    public class GetByUserIdCommandHandler : IRequestHandler<GetByUserIdCommand, List<WithdrawResponse>>
    {
        private readonly IMetroPickUpDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public GetByUserIdCommandHandler(IMetroPickUpDbContext dbContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<WithdrawResponse>> Handle(GetByUserIdCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _userManager.FindByIdAsync(request.UserId);
            if (applicationUser == null)
            {
                throw new NotFoundException("WithdraId không tồn tại");
            }
            var wR = await _dbContext.WithDraw.Where(x => x.ApplicationUserID == applicationUser.Id).OrderByDescending(x => x.Created).ToListAsync();
            var result = new List<WithdrawResponse>();
            foreach (var w in wR)
            {
                var paymentmethod = await _dbContext.PaymentMethod.Where(x => x.Id == w.PaymentMethodID).SingleOrDefaultAsync();
                var data = new WithdrawResponse()
                {
                    Id = w.Id,
                    Balance = w.Balance,
                    Deposit = w.Deposit,
                    ApplicationUserID = w.ApplicationUserID,
                    PaymentMethodID = w.PaymentMethodID,
                    Created = w.Created,

                    CustomerData = _mapper.Map<CustomerData>(applicationUser),
                    PaymentMethodData = _mapper.Map<PaymentMethodResponse>(paymentmethod)
                };
                result.Add(data);
            }
            return result;
        }
    }
}
