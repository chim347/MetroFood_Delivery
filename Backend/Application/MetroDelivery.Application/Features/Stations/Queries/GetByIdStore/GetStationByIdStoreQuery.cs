using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stations.Queries.GetByIdStore
{
    public class GetStationByIdStoreQuery : IRequest<StationResponse>
    {
        public string StationId { get; set; }
    }
}
