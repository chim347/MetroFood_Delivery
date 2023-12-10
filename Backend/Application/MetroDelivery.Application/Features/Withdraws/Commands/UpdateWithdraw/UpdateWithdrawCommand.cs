using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Withdraws.Commands.UpdateWithdraw
{
    public class UpdateWithdrawCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
        public string ApplicationUserID { get; set; }
        public string PaymentMethodID { get; set; }
        public double? Balance { get; set; }
        public double? Deposit { get; set; }
        public DateTime? CreateTimeOfWithdraw { get; set; }
    }

    public class UpdateWithdrawCommandHandler : IRequestHandler<UpdateWithdrawCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public UpdateWithdrawCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }
        public async Task<MetroPickUpResponse> Handle(UpdateWithdrawCommand request, CancellationToken cancellationToken)
        {
            var customerExist = await _metroPickUpDbContext.ApplicationUsers.Where(c => c.Id == request.ApplicationUserID).SingleOrDefaultAsync();
            var paymentMethodExist = await _metroPickUpDbContext.PaymentMethod.Where(c => c.Id == Guid.Parse(request.PaymentMethodID)).SingleOrDefaultAsync();
            var withdrawExist = await _metroPickUpDbContext.WithDraw.Where(c => c.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (withdrawExist == null) {
                throw new NotFoundException("WithdrawId không tồn tại");
            }
            if (withdrawExist.IsDelete == true) {
                throw new NotFoundException("WithdrawId đã bị xóa");
            }
            if (customerExist == null) {
                throw new NotFoundException("CustomerId không tồn tại");
            }
            if (customerExist.EmailConfirmed == false) {
                throw new NotFoundException("CustomerId đã bị xóa");
            }
            if (paymentMethodExist == null) {
                throw new NotFoundException("PaymentMethodId không tồn tại");
            }
            if (paymentMethodExist.IsDelete == true) {
                throw new NotFoundException("PaymentMethodId đã bị xóa");
            }

            withdrawExist.ApplicationUserID = request.ApplicationUserID;
            withdrawExist.PaymentMethodID = Guid.Parse(request.PaymentMethodID);
            withdrawExist.Balance = request.Balance;
            withdrawExist.Deposit = request.Deposit;
            withdrawExist.CreateTimeOfWithdraw = request.CreateTimeOfWithdraw;

            _metroPickUpDbContext.WithDraw.Update(withdrawExist);
            await _metroPickUpDbContext.SaveChangesAsync();
            return new MetroPickUpResponse
            {
                Message = "Update Successfully"
            };
        }
    }
}
