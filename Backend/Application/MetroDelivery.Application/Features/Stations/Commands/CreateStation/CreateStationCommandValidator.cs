using FluentValidation;

namespace MetroDelivery.Application.Features.Stations.Commands.CreateStation
{
    public class CreateStationCommandValidator : AbstractValidator<CreateStationCommand>
    {
        public CreateStationCommandValidator()
        {
            RuleFor(p => p.StoreID)
                .NotEmpty().WithMessage("{StoreID} is required")
                .NotNull();

            RuleFor(p => p.StationName)
                .NotEmpty().WithMessage("{StationName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{StationName} must be fewer than 100 characters");
        }
    }
}
