using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Models.Identity
{
    public class AuthenticationResult
    {
        public string AccessToken { get; set; } 
        public string RefreshToken{ get; set; } 

        // ngay het han
        public DateTime Expires { get; set; } 
    }
}
