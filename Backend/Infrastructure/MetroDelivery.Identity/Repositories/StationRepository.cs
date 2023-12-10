using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Identity.DbContexts;

namespace MetroDelivery.Identity.Repositories
{
    public class StationRepository : GenericRepository<Station>, IStationRepository
    {
        public StationRepository(MetroPickupIdentityDbContext context) : base(context)
        {
        }
    }
}
