using FluentValidation;

namespace MetroDelivery.Application.Features.Menus.Commands.CreateMenu
{
    public class CreateMennuCommandValidator : AbstractValidator<CreateMennuCommand>
    {
        public CreateMennuCommandValidator()
        {
            RuleFor(p => p.MenuName)
               .NotEmpty().WithMessage("{MenuName} is required")
               .NotNull();

            RuleFor(p => p.StartTimeService)
                .NotEmpty().WithMessage("{StartTimeService} is required")
                .NotNull();

            RuleFor(p => p.EndTimeService)
                .NotEmpty().WithMessage("{EndTimeService} is required")
                .NotNull();
        }
    }
}
