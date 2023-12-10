using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stations.Queries.GetAllStation
{
    public class GetListStationQuery : IRequest<List<StationResponse>>
    {
    }
}
