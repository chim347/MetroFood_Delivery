using FluentValidation;

namespace MetroDelivery.Application.Features.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreCommandValidator()
        {
            RuleFor(p => p.StoreName)
                .NotEmpty().WithMessage("{StoreName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{StoreName} must be fewer than 100 characters");

            RuleFor(p => p.StoreLocation)
                .NotEmpty().WithMessage("{StoreLocation} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{StoreLocation} must be fewer than 100 characters");
        }
    }
}
