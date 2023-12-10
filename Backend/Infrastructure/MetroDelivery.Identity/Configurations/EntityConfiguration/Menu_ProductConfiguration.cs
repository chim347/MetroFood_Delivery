using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class Menu_ProductConfiguration : IEntityTypeConfiguration<Menu_Product>
    {
        public void Configure(EntityTypeBuilder<Menu_Product> builder)
        {
            builder.HasData(
                new Menu_Product
                {
                    MenuID = Guid.Parse("D3FD2009-C658-4498-BF59-26936918A0C8"),
                    ProductID = Guid.Parse("43203CE4-D82C-4C78-8794-2AEF22D7EC5B"),
                    PriceOfProductBelongToTimeService = 20000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    ProductID = Guid.Parse("E802B6C5-F08E-4EFF-B7E7-AF95514B4341"),
                    PriceOfProductBelongToTimeService = 15000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    ProductID = Guid.Parse("FFB05663-954D-4AF3-8A41-91AF39446F81"),
                    PriceOfProductBelongToTimeService = 1000    // 1000/1cay
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("F31C789C-4A46-45C7-9009-D36681D788C5"),
                    PriceOfProductBelongToTimeService = 30000 // 30/ 1thanh socola 
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    ProductID = Guid.Parse("107F1F75-B23B-4BC4-92D7-F2E90D067D1F"),
                    PriceOfProductBelongToTimeService = 50000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("1616CC05-8C82-4F8B-A6E0-F60AB3DE0D38"),
                    PriceOfProductBelongToTimeService = 35000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("43203CE4-D82C-4C78-8794-2AEF22D7EC5B"),
                    PriceOfProductBelongToTimeService = 35000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("4C9EC4B9-1C16-4C7A-90BF-D620AAB257B6"),
                    PriceOfProductBelongToTimeService = 159000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("0C308B93-B26A-4224-9D63-28294711AA15"),
                    PriceOfProductBelongToTimeService = 100000 // 100/4mieng ga
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("B834CF11-CC28-4E7D-9846-2ACC8AD33D8C"),
                    PriceOfProductBelongToTimeService = 25000 
                },

                // q1 -> bến xe miền đông
                new Menu_Product
                {
                    MenuID = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    ProductID = Guid.Parse("0C308B93-B26A-4224-9D63-28294711AA15"),
                    PriceOfProductBelongToTimeService = 100000 // 100/4mieng ga
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    ProductID = Guid.Parse("B834CF11-CC28-4E7D-9846-2ACC8AD33D8C"),
                    PriceOfProductBelongToTimeService = 25000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    ProductID = Guid.Parse("43203CE4-D82C-4C78-8794-2AEF22D7EC5B"),
                    PriceOfProductBelongToTimeService = 35000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    ProductID = Guid.Parse("4C9EC4B9-1C16-4C7A-90BF-D620AAB257B6"),
                    PriceOfProductBelongToTimeService = 159000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("43203CE4-D82C-4C78-8794-2AEF22D7EC5B"),
                    PriceOfProductBelongToTimeService = 20000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("E802B6C5-F08E-4EFF-B7E7-AF95514B4341"),
                    PriceOfProductBelongToTimeService = 15000
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("FFB05663-954D-4AF3-8A41-91AF39446F81"),
                    PriceOfProductBelongToTimeService = 1000    // 1000/1cay
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("F31C789C-4A46-45C7-9009-D36681D788C5"),
                    PriceOfProductBelongToTimeService = 30000 // 30/ 1thanh socola 
                },
                new Menu_Product
                {
                    MenuID = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ProductID = Guid.Parse("107F1F75-B23B-4BC4-92D7-F2E90D067D1F"),
                    PriceOfProductBelongToTimeService = 50000
                }
            );
        }
    }
}
