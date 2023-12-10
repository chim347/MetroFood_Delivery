using MediatR;
using MetroDelivery.Application.Features.Stations.Commands.CreateStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stores.Commands.CreateStores
{
    public class CreateStoreCommand : IRequest<Guid>
    {
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public TimeSpan? StoreOpenTime { get; set; }
        public TimeSpan? StoreCloseTime { get; set; }
    }
}
