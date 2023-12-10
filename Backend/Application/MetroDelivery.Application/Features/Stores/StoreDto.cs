using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stores
{
    public class StoreDto
    {
        public Guid Id { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public TimeSpan StoreOpenTime { get; set; }
        public TimeSpan StoreCloseTime { get; set; }
    }
}
