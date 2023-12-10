using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Identity.DbContexts;

namespace MetroDelivery.Identity.Repositories
{
    public class RouteStationRepository : GenericRepository<Route_Station>, IRouteStationRepository
    {
        public RouteStationRepository(MetroPickupIdentityDbContext context) : base(context)
        {
        }
    }
}
