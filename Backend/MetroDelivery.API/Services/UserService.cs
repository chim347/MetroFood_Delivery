using MetroDelivery.Application.Contracts.Identity;
using MetroDelivery.Application.Models.Identity;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MetroDelivery.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId { get => _httpContextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<EndUser> GetUser(string userId)
        {
            var endUser = await _userManager.FindByIdAsync(userId);
            return new EndUser
            {
                Email = endUser.Email,
                Id = endUser.Id,
                FirstName = endUser.FirstName,
                LastName = endUser.LastName
            };
        }

        public async Task<List<EndUser>> GetUsers()
        {
            var endUser = await _userManager.GetUsersInRoleAsync("EndUser");
            return endUser.Select(q => new EndUser
            {
                Id = q.Id,
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName
            }).ToList();
        }
    }
}
