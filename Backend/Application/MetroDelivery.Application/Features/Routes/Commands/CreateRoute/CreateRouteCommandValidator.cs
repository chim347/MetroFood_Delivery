using FluentValidation;

namespace MetroDelivery.Application.Features.Routes.Commands.CreateRoute
{
    public class CreateRouteCommandValidator : AbstractValidator<CreateRouteCommand>
    {
        public CreateRouteCommandValidator()
        {
            RuleFor(p => p.FromLocation)
                .NotEmpty().WithMessage("{FromLocation} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{FromLocation} must be fewer than 100 characters");

            RuleFor(p => p.ToLocation)
                .NotEmpty().WithMessage("{ToLocation} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{ToLocation} must be fewer than 100 characters"); ;
            
        }
    }
}
