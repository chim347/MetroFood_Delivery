using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contant;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Application.Features.Products.Commands.CreateProducts;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Products.Commands.UpdateProducts
{
    public class UpdateProductCommand : IRequest<MetroPickUpResponse>
    {
        public string ProductId {  get; set; }

        public string CategoryID { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productExistId = await _metroPickUpDbContext.Product.Where(p => p.Id == Guid.Parse(request.ProductId)).SingleOrDefaultAsync();
            if (productExistId == null) {
                throw new NotFoundException($"ProductId {request.ProductId} không tồn tại");
            }
            if (productExistId.IsDelete == true) {
                throw new NotFoundException($"ProductId {request.ProductId} đã bị xóa khỏi danh sách Product");
            }

            var checkCategory = await _metroPickUpDbContext.Categories.Where(c => c.Id == Guid.Parse(request.CategoryID) && !c.IsDelete).SingleOrDefaultAsync();
            if (checkCategory == null) {
                throw new NotFoundException($"CategoryId này {request.CategoryID} không tồn tại trong danh sách category");
            }

            var validator = new UpdateProductCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (validatorResult.Errors.Any()) {
                throw new BadRequestException("Invalid update product", validatorResult);
            }

            productExistId.CategoryID = checkCategory.Id;
            productExistId.ProductName = request.ProductName;
            productExistId.ProductDescription = request.ProductDescription;
            productExistId.Image = request.Image;
            productExistId.Price = request.Price;

            _metroPickUpDbContext.Product.Update(productExistId);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Update product successfully"
            };
        }
    }
}
