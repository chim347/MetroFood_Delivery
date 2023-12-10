using FluentValidation;

namespace MetroDelivery.Application.Features.Products.Commands.CreateProducts
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("{ProductName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{ProductName} must be fewer than 100 characters");

            RuleFor(p => p.ProductDescription)
                .MaximumLength(500).WithMessage("{ProductDescription} must be fewer than 500 characters");

            RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(0).WithMessage("{Price} must be greater than or equal to 0");

            RuleFor(p => p.Image)
                .NotEmpty().WithMessage("{Image} is required")
                .NotNull()
                .MaximumLength(1000).WithMessage("{Image} must be fewer than 1000 characters");

        }
    }
}
