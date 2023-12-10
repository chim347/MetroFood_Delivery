using FluentValidation;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Customers.Commands.CreateCustomer;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommand : IRequest<MetroPickUpResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public string StoreId { get; set; }
    }

    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public CreateStaffCommandHandler(IMetroPickUpDbContext metroPickUpDbContext,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<MetroPickUpResponse> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            // check email
            var emailExist = await _userManager.FindByEmailAsync(request.Email);
            if (emailExist != null) {
                throw new BadRequestException("The username already exists!");
            }
            // validate incoming data
            var validator = new CreateStaffCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (validatorResult.Errors.Any()) {
                throw new BadRequestException("Invalid Create user", validatorResult);
            }

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = request.Email.ToUpper(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                PhoneNumber = request.Phone,
                StoreId = Guid.Parse(request.StoreId),
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                Created = DateTime.Now
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(user, "Staff");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            else {
                throw new BadRequestException("Account creation failed !");

            }

            await _metroPickUpDbContext.SaveChangesAsync();

            // return record id
            return new MetroPickUpResponse { 
                Message = "Create Staff Successfully"
            };
        }
    }
    public class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand>
    {

        public CreateStaffCommandValidator()
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
