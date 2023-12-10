using AutoMapper;
using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Categorys.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryExist = await _metroPickUpDbContext.Categories.Where(c => c.CategoryName == request.CategoryName && !c.IsDelete).SingleOrDefaultAsync();
            if (categoryExist != null) {
                throw new NotFoundException("category đã tồn tại rồi!!");
            }

            var validator = new CreateCategoryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (validatorResult.Errors.Any()) {
                throw new BadRequestException("Invalid Create user", validatorResult);
            }

            var category = new Category
            {
                CategoryName = request.CategoryName,
            };
            _metroPickUpDbContext.Categories.Add(category);
            await _metroPickUpDbContext.SaveChangesAsync();

            return category.Id;
        }
    }
}
