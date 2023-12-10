/*using FluentValidation;

namespace MetroDelivery.Application.Features.OrderDetails.Commands.CreateOrderDetail
{
    public class CreateOrderDetailCommandValidator : AbstractValidator<CreateOrderDetailCommand>
    {
        public CreateOrderDetailCommandValidator()
        {
            RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(0).WithMessage("{Price} must be greater than or equal to 0");

        }
    }
}
*/