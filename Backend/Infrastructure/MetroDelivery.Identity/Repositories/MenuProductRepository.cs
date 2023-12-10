using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Identity.DbContexts;

namespace MetroDelivery.Identity.Repositories
{
    public class MenuProductRepository : GenericRepository<Menu_Product>, IMenuProductRepository
    {
        public MenuProductRepository(MetroPickupIdentityDbContext context) : base(context)
        {
        }
    }
}
