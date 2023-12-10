using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Logging;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Application.Features.Customers.Queries.GetAllCustomers;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetListCustomerQuery> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UpdateCustomerCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper, IAppLogger<GetListCustomerQuery> logger,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<MetroPickUpResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data
            var customer = await _metroPickUpDbContext.ApplicationUsers.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            if (customer == null) {
                throw new NotFoundException("Customer does not exist !");
            }
            else if (customer.EmailConfirmed == false) {
                throw new NotFoundException("The customer have been deleted");
            }
            var validator = new UpdateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any()) {
                _logger.LogWarning("Validation errors in update for {0} - {1}", nameof(ApplicationUser), request.Id);
                throw new BadRequestException("Invalid Customer", validationResult);
            }

            customer.PhoneNumber = request.Phone;
            customer.Birthday = request.Birthday;
            customer.Address = request.Address;
            customer.Wallet = request.Wallet;
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            

            // add database
            _metroPickUpDbContext.ApplicationUsers.Update(customer);
            await _metroPickUpDbContext.SaveChangesAsync();


            var user = await _userManager.FindByIdAsync(customer.Id);
            if (user != null) {
                var userRoles = await _userManager.GetRolesAsync(user);
                // Xóa role hiện tại
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                //Add role mới vào
                await _userManager.AddToRoleAsync(user, "EndUser");
            }

            // return
            return new MetroPickUpResponse { 
                Message = "Update Customer Successfully" 
            };
        }
    }
}
