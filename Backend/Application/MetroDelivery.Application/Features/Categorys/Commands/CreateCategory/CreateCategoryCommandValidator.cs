using FluentValidation;

namespace MetroDelivery.Application.Features.Categorys.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("{CategoryName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{CategoryName} must be fewer than 100 characters");

            
        }
    }
}
