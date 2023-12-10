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

namespace MetroDelivery.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<MetroPickUpResponse>
    {
        public string OrderId { get; set; }
        // chỉ cho update mỗi status của order thôi
        public int OrderStatus { get; set; }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        /*private readonly IMapper _mapper;*/
        public UpdateOrderCommandHandler(IMetroPickUpDbContext metroPickUpDbContext/*, IMapper mapper*/)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            /*_mapper = mapper;*/
        }

        public async Task<MetroPickUpResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _metroPickUpDbContext.Order.Where(o => o.Id == Guid.Parse(request.OrderId)).SingleOrDefaultAsync();
            if (order == null) {
                throw new NotFoundException("OrderId không tồn tại!!");
            }

            order.OrderStatus = request.OrderStatus;
            _metroPickUpDbContext.Order.Update(order);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Update Status Order Successfully"
            };
        }
    }
}
