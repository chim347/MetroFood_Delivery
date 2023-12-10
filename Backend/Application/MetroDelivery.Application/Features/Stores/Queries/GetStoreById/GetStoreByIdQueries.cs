using MediatR;
using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stores.Queries.GetStoreById
{
    public class GetStoreByIdQueries : IRequest<StoreDto>
    {
        public string Id { get; set; }
    }
}
