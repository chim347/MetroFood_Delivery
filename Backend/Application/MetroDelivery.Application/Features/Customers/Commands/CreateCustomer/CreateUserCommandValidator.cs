using FluentValidation;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Application.Features.Customers.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateUserCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{FirstName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{FirstName} must be fewer than 10 characters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{LastName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{LastName} must be fewer than 10 characters");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required")
                .NotNull()
                .MaximumLength(50).WithMessage("Password must be fewer than 50 characters")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).+$")
                .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email is required")
                .NotNull()
                .MaximumLength(100).WithMessage("Email must be fewer than 100 characters")
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                .WithMessage("Invalid email address");

            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("Phone number is required")
                .NotNull()
                .Matches(@"^\d{10}$")
                .WithMessage("Invalid phone number");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Address is required")
                .NotNull()
                .MaximumLength(100).WithMessage("Address must be fewer than 100 chrarcters");



        }
    }
}
