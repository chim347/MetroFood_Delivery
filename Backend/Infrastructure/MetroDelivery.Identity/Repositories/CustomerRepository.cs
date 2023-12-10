/*using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Identity.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Identity.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        
        public CustomerRepository(MetroPickupIdentityDbContext metroDeliveryDatabaseContext) : base(metroDeliveryDatabaseContext)
        {
            
        }

        public async Task<bool> IsCustomerEmailUnique(string email)
        {
            return await _metroDeliveryDatabaseContext.Customer.AllAsync(x => x.ApplicationUser.Email == email) == false;
        }

        public async Task<Customer> CustomerIdMusBeExist(Guid id)
        {
            return await _metroDeliveryDatabaseContext.Customer.Include(q => q.ApplicationUser).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<bool> IsBeUniqueCustomerName(string customerName)
        {
            return await _metroDeliveryDatabaseContext.Customer.AllAsync(x => x.ApplicationUser.UserName == customerName) == false;
        }
    }
}
*/