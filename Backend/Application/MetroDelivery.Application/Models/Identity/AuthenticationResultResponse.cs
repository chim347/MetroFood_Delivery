using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Models.Identity
{
    public class AuthenticationResultResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid? StoreId { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        // ngay het han
        public DateTime Expires { get; set; }
    }
}
