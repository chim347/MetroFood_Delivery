using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
    }
}
