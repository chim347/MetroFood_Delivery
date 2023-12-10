using MediatR;
using MetroDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stores.Queries.GetAllStores
{
    public class GetListStoreQueries : IRequest<List<StoreDto>>
    {

    }
}
