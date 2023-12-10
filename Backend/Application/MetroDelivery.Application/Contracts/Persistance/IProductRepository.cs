using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Domain.Entities;

namespace MetroDelivery.Application.Contracts.Persistance
{
    public interface IProductRepository : IGenericRepository<Product>
    {

        //public Task<MetroPickUpResponse> CheckMinusProduct(string ProductID, string storeId);

    }

}
