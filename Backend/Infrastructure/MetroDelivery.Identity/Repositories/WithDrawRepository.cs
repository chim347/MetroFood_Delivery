using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Identity.DbContexts;

namespace MetroDelivery.Identity.Repositories
{
    public class WithDrawRepository : GenericRepository<WithDraw>, IWithDrawRepository
    {
        public WithDrawRepository(MetroPickupIdentityDbContext context) : base(context)
        {
        }
    }
}
