using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Stores.Commands.CreateStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public TimeSpan? StoreOpenTime { get; set; }
        public TimeSpan? StoreCloseTime { get; set; }
    }
}
