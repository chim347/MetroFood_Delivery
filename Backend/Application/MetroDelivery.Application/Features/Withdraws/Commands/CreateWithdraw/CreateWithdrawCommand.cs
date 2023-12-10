using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Withdraws.Commands.CreateWithdraw
{
    /// <summary>
    /// Lưu lại lịch sử nộp tiền
    /// </summary>
    public class CreateWithdrawCommand : IRequest<Guid>
    {
        public string ApplicationUserID { get; set; } = null!;
        public double? Deposit { get; set; }
    }

    public class CreateWithdrawCommandHandler : IRequestHandler<CreateWithdrawCommand, Guid>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper _mapper;

        public CreateWithdrawCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            this.userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateWithdrawCommand request, CancellationToken cancellationToken)
        {

            var applicationUser = await userManager.FindByIdAsync(request.ApplicationUserID);
            if(applicationUser.Wallet == null)
            {
                applicationUser.Wallet = 0;
            }
           
            // insert
            var withdraw = new WithDraw
            {
                ApplicationUserID = request.ApplicationUserID,
                Balance = applicationUser.Wallet,
                PaymentMethodID = Guid.Parse("47BD4DD4-3FB4-463E-B9B9-5EBFB7E1F960"),
                Deposit = request.Deposit,
            };
            applicationUser.Wallet += request.Deposit;
            _metroPickUpDbContext.WithDraw.Add(withdraw);

            await userManager.UpdateAsync(applicationUser);
            await _metroPickUpDbContext.SaveChangesAsync();

            return withdraw.Id;
        }
    }
}
