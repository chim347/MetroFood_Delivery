using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Logging;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace MetroDelivery.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public CreateCustomerCommandHandler(IMetroPickUpDbContext metroPickUpDbContext,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<MetroPickUpResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // check email
            var emailExist = await _userManager.FindByEmailAsync(request.Email);
            if (emailExist != null) {
                throw new BadRequestException("The username already exists!");
            }
            // validate incoming data
            var validator = new CreateUserCommandValidator();
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
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                Created = DateTime.Now
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(user, "EndUser");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            else {
                throw new BadRequestException("Account creation failed !");

            }

            await _metroPickUpDbContext.SaveChangesAsync();

            // return record id
            return new MetroPickUpResponse { 
                Message = "Create account Successfully"
            };
        }

    }
}
