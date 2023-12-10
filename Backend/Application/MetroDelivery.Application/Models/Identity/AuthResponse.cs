using MetroDelivery.Application.Features.Stations.Queries;

namespace MetroDelivery.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        // ngay het han
        public DateTime Expires { get; set; }
        public Guid? StoreId { get; set; }
        public StoreData? StoreData { get; set; }
    }
}
