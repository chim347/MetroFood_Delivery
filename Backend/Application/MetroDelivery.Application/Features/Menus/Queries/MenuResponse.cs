using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Menus.Queries
{
    public class MenuResponse
    {
        public Guid Id { get; set; }
        public string MenuName { get; set; }
        public TimeSpan StartTimeService { get; set; }
        public TimeSpan EndTimeService { get; set; }
    }
}
