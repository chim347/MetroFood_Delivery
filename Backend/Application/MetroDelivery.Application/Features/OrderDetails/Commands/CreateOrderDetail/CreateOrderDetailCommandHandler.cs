/*using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.OrderDetails.Commands.CreateOrderDetail
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, Guid>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public CreateOrderDetailCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var productExist = await _metroPickUpDbContext.Product.Where(p => p.Id == request.ProductID && !p.IsDelete).SingleOrDefaultAsync();
            if(productExist == null) {
                throw new NotFoundException("ProductId không tồn tại");
            }

            var orderExist = await _metroPickUpDbContext.Order.Where(p => p.Id == request.OrderID && !p.IsDelete).SingleOrDefaultAsync();
            if (orderExist == null) {
                throw new NotFoundException("OrderId không tồn tại");
            }

            var createdOrder = orderExist.Created;
            var menus = await _metroPickUpDbContext.Menu.Where(m => (m.StartTimeService <= createdOrder.TimeOfDay) && (m.EndTimeService > createdOrder.TimeOfDay)).SingleOrDefaultAsync();
            if (menus == null) {
                throw new NotFoundException("Cửa hàng đã đóng cửa, xin quý khách quay lại vào 6h sáng mai");
            }
            var store = await _metroPickUpDbContext.Store.Where(s => s.Id == orderExist.StoreID && !s.IsDelete).SingleOrDefaultAsync();
            if (store == null) {
                throw new NotFoundException("StoreId không tồn tại trong order");
            }
            var menuProduct = await _metroPickUpDbContext.Menu_Product.Where(s => !s.IsDelete && s.ProductID == request.ProductID && s.Menu.StartTimeService == menus.StartTimeService && s.Menu.EndTimeService == menus.EndTimeService).SingleOrDefaultAsync();
            if(menuProduct == null) {
                throw new NotFoundException("không tồn tại product trong khoảng thời gian phục vụ này");
            }

            var validator = new CreateOrderDetailCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (validatorResult.Errors.Any()) {
                throw new BadRequestException("Invalid Create user", validatorResult);
            }

            var orderDetail = new OrderDetail
            {
                ProductID = menuProduct.ProductID,
                OrderID = request.OrderID,
                
                Quanity = request.Quanity,
                Price = menuProduct.PriceOfProductBelongToTimeService,
            };

            _metroPickUpDbContext.OrderDetail.Add(orderDetail);
            await _metroPickUpDbContext.SaveChangesAsync();
            return orderDetail.Id;
        }
    }
}
*/