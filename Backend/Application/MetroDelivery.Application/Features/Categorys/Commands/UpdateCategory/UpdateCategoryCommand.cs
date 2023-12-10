using AutoMapper;
using FluentValidation;
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

namespace MetroDelivery.Application.Features.Categorys.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryExist = await _metroPickUpDbContext.Categories.Where(c => c.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (categoryExist == null) {
                throw new NotFoundException("category không tồn tồn tại!");
            }
            if (categoryExist.IsDelete == true) {
                throw new NotFoundException("category đã bị xóa!");
            }

            var validator = new UpdateCategoryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (validatorResult.Errors.Any()) {
                throw new BadRequestException("Invalid Create user", validatorResult);
            }

            categoryExist.CategoryName = request.CategoryName;
            _metroPickUpDbContext.Categories.Update(categoryExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Update Successfully"
            };
        }
    }

    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("{CategoryName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{CategoryName} must be fewer than 100 characters");
        }
    }
}
