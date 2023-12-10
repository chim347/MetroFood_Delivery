using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Identity;
using MetroDelivery.Domain.Common;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Domain.IdentityModels;
using MetroDelivery.Identity.DbContexts.Interceptor;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Identity.DbContexts
{
    public class MetroPickupIdentityDbContext : IdentityDbContext<ApplicationUser>, IMetroPickUpDbContext
    {
        /*private readonly IUserService _userService;
        private readonly IMediator _mediator;*/
        /*private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;*/

        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Menu_Product> Menu_Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Route_Station> Route_Station { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Store_Menu> Store_Menu { get; set; }
        public DbSet<Trip> Trip { get; set; }
        public DbSet<Station_Trip> Station_Trip { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<WithDraw> WithDraw { get; set; }
        public DbSet<PaymentHistory> PaymentHistory { get; set; }

        public MetroPickupIdentityDbContext(DbContextOptions<MetroPickupIdentityDbContext> options/*,
            IMediator mediator,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor*/) : base(options)
        {
            /*_mediator = mediator;
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;*/
        }

        /*public MetroPickupIdentityDbContext(IUserService userService)
        {
            _userService = userService;
        }*/

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.ApplyConfigurationsFromAssembly(typeof(MetroPickupIdentityDbContext).Assembly);
            base.OnModelCreating(builder);
        }



        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }*/

        /*public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }*/
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseAuditableEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified)) {
                entry.Entity.LastModified = DateTime.Now;
                if (entry.State == EntityState.Added) {
                    entry.Entity.Created = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public int SaveChanges(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
