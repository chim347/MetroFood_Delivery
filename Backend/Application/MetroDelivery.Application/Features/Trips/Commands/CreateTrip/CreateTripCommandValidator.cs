using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Trips.Commands.CreateTrip
{
    public class CreateTripCommandValidator : AbstractValidator<CreateTripCommand>
    {
        public CreateTripCommandValidator()
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
