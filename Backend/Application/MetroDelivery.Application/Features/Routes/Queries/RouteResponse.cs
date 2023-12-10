using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Routes.Queries
{
    public class RouteResponse
    {
        public Guid Id { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }

    }
}
