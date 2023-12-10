using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Products.Commands.CreateProducts
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var checkCategory = await _metroPickUpDbContext.Categories.Where(c => c.Id == Guid.Parse(request.CategoryID) && !c.IsDelete).SingleOrDefaultAsync();
            if(checkCategory == null) {
                throw new NotFoundException($"CategoryId này {request.CategoryID} không tồn tại trong danh sách category");
            }

            var validator = new CreateProductCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (validatorResult.Errors.Any()) {
                throw new BadRequestException("Invalid Create user", validatorResult);
            }

            var product = new Product
            {
                CategoryID = Guid.Parse(request.CategoryID),
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                Image = request.Image,
                Price = request.Price,
            };

            _metroPickUpDbContext.Product.Add(product);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Create product thành công"
            };
                
        }
    }
}
