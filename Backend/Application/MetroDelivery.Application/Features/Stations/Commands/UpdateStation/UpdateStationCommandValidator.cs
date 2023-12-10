using FluentValidation;

namespace MetroDelivery.Application.Features.Stations.Commands.UpdateStation
{
    public class UpdateStationCommandValidator : AbstractValidator<UpdateStationCommand>
    {
        public UpdateStationCommandValidator()
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
