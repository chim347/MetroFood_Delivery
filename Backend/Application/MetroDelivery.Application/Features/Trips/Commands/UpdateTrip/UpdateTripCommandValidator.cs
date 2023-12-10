using FluentValidation;

namespace MetroDelivery.Application.Features.Trips.Commands.UpdateTrip
{
    public class UpdateTripCommandValidator : AbstractValidator<UpdateTripCommand>
    {
        public UpdateTripCommandValidator()
        {
            RuleFor(p => p.TripName)
                .NotEmpty().WithMessage("{TripName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{TripName} must be fewer than 100 characters");

            RuleFor(p => p.TripStartTime)
                .NotEmpty().WithMessage("{TripStartTime} is required")
                .NotNull();

            RuleFor(p => p.TripEndTime)
                .NotEmpty().WithMessage("{TripEndTime} is required")
                .NotNull();
        }
    }
}
