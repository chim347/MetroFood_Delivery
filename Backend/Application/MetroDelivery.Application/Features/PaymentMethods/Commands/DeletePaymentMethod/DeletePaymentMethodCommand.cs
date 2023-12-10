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

namespace MetroDelivery.Application.Features.PaymentMethods.Commands.DeletePaymentMethod
{
    public class DeletePaymentMethodCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
    }

    public class DeletePaymentMethodCommandHandler : IRequestHandler<DeletePaymentMethodCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeletePaymentMethodCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var paymentExist = await _metroPickUpDbContext.PaymentMethod.Where(p => p.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (paymentExist == null) {
                throw new NotFoundException("paymentMethod không tồn tại!");
            }
            if (paymentExist.IsDelete == true) {
                throw new NotFoundException("paymentMethod đã bị xóa!");
            }

            paymentExist.IsDelete = true;
            _metroPickUpDbContext.PaymentMethod.Update(paymentExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Delete paymentMethod Successfull"
            };
        }
    }
}
