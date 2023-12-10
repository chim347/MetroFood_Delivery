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

namespace MetroDelivery.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod
{
    public class UpdatePaymentMethodCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
        public string PaymentMethodName { get; set; }
    }

    public class UpdatePaymentMethodCommandHandler : IRequestHandler<UpdatePaymentMethodCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public UpdatePaymentMethodCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var response = await _metroPickUpDbContext.PaymentMethod.Where(p => p.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (response == null) {
                throw new NotFoundException("paymentMethod không tồn tại!");
            }
            if (response.IsDelete == true) {
                throw new NotFoundException("paymentMethod đã bị xóa!");
            }

            response.PaymentMethodName = request.PaymentMethodName;
            _metroPickUpDbContext.PaymentMethod.Update(response);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Update Successfully"
            };
        }
    }
}
