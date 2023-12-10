using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace MetroDelivery.Application.Features.Auth.Queries.ChangePassword
{
    public class ChangePasswordQueryHandler : IRequestHandler<ChangePasswordQuery, string>
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public ChangePasswordQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(ChangePasswordQuery request, CancellationToken cancellationToken)
        {
            var emailUser = await _userManager.FindByEmailAsync(request.Email);
            if (emailUser == null)
                throw new NotFoundException("Email " + request.Email + " not exist!");

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(emailUser, request.CurrentPassword);
            if (!isPasswordCorrect) {
                throw new BadRequestException("Current password is incorrect.");
            }


            var changePasswordResult = await _userManager.ChangePasswordAsync(emailUser, request.CurrentPassword, request.NewPassword);
            if (!changePasswordResult.Succeeded) {
                throw new BadRequestException("Unable to change password");
            }
            return ("Password successfully changed.");
        }
    }
}
