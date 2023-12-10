using MetroDelivery.Application.Models.Identity;

namespace MetroDelivery.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<EndUser>> GetUsers();
        Task<EndUser> GetUser(string userId);
        public string UserId { get; }
    }
}
