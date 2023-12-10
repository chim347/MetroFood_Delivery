using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Stations.Commands.CreateStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stations.Commands.UpdateStation
{
    public class UpdateStationCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
        public string StoreID { get; set; }
        public string StationName { get; set; }
    }
}
