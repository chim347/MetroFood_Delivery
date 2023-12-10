using FluentValidation;

namespace MetroDelivery.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
           /* RuleFor(p => p.Products)
            .GreaterThanOrEqualTo(0).WithMessage("{Price} must be greater than or equal to 0");*/

        }
    }

    public class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValidator()
        {
            RuleFor(p => p.PriceOfProductBelongToTimeService)
            .GreaterThanOrEqualTo(0).WithMessage("{Price} must be greater than or equal to 0");

        }
    }
}
