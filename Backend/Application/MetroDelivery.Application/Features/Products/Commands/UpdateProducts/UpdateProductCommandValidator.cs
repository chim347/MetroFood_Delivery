using FluentValidation;
using System;

namespace MetroDelivery.Application.Features.Products.Commands.UpdateProducts
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("{ProductId} is required")
                .NotNull().WithMessage("{ProductId} cannot be null");

            RuleFor(p => p.CategoryID)
                .NotEmpty().WithMessage("{CategoryID} is required")
                .NotNull().WithMessage("{CategoryID} cannot be null");

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
