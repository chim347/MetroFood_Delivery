using MetroDelivery.Domain.Entities;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Common.Interface
{
    public interface IMetroPickUpDbContext
    {
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

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public int SaveChanges(CancellationToken cancellationToken = default);

    }
}
