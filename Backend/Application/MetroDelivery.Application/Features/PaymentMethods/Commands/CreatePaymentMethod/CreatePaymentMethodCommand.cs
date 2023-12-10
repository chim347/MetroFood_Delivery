using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.PaymentMethods.Commands.CreatePaymentMethod
{
    public class CreatePaymentMethodCommand : IRequest<Guid>
    {
        public string PaymentMethodName { get; set; }
    }

    public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, Guid>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public CreatePaymentMethodCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var paymentMedthod = await _metroPickUpDbContext.PaymentMethod.Where(p => p.PaymentMethodName == request.PaymentMethodName).SingleOrDefaultAsync();
            if (paymentMedthod != null) {
                throw new NotFoundException("paymentMethod này đã tồn tại rồi!");
            }

            var payemnt = new PaymentMethod
            {
                PaymentMethodName = request.PaymentMethodName,
            };
            _metroPickUpDbContext.PaymentMethod.Add(payemnt);
            await _metroPickUpDbContext.SaveChangesAsync();

            return payemnt.Id;
        }
    }
}
