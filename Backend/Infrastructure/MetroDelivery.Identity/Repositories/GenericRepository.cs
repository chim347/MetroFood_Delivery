using MediatR;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Domain.Common;
using MetroDelivery.Domain.IdentityModels;
using MetroDelivery.Identity.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Identity.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
    {
        protected readonly MetroPickupIdentityDbContext _metroDeliveryDatabaseContext;

        public GenericRepository(MetroPickupIdentityDbContext context)
        {
            _metroDeliveryDatabaseContext = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _metroDeliveryDatabaseContext.AddAsync(entity);
            await _metroDeliveryDatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            entity.IsDelete = true;
            _metroDeliveryDatabaseContext.Set<T>().Update(entity);
            await _metroDeliveryDatabaseContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _metroDeliveryDatabaseContext.Set<T>().AsNoTracking().Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _metroDeliveryDatabaseContext.Set<T>().AsNoTracking().Where(q => q.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _metroDeliveryDatabaseContext.Update(entity);
            _metroDeliveryDatabaseContext.Entry(entity).State = EntityState.Modified;
            await _metroDeliveryDatabaseContext.SaveChangesAsync();
        }
    }
}
