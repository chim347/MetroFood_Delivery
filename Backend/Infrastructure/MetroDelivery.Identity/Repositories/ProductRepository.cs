using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Contant;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Identity.DbContexts;

namespace MetroDelivery.Identity.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MetroPickupIdentityDbContext context) : base(context)
        {
        }

        /*public async Task<MetroPickUpResponse> CheckMinusProduct(string productID, string storeId)
        {
            var product = _metroDeliveryDatabaseContext.Products.Where(x => x.Id == Guid.Parse(productID) && x.StoreID == Guid.Parse(storeId)).SingleOrDefault();

            int quantityOfProduct = 0;
            if (product != null) {
                quantityOfProduct = product.Stock;
            }
            if (quantityOfProduct > 0) {
                return await Task.FromResult(new MetroPickUpResponse
                {
                    Message = Extension.Ok
                });
            }
            return await Task.FromResult(new MetroPickUpResponse
            {
                Message = Extension.OutOfStock
            }); ;
        }*/
    }
}
