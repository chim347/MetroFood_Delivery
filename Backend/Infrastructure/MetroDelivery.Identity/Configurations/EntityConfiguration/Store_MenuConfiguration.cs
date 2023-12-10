using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class Store_MenuConfiguration : IEntityTypeConfiguration<Store_Menu>
    {
        public void Configure(EntityTypeBuilder<Store_Menu> builder)
        {
            builder.HasData(
                new Store_Menu
                {
                    StoreId = Guid.Parse("AA2610A8-DE94-42B7-B12B-1CF8710E05D8"),
                    MenuId = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ApplyDate = "Thursday",
                    Priority = true
                },
                new Store_Menu
                {
                    StoreId = Guid.Parse("AA2610A8-DE94-42B7-B12B-1CF8710E05D8"),
                    MenuId = Guid.Parse("D3FD2009-C658-4498-BF59-26936918A0C8"),
                    ApplyDate = "Thursday",
                    Priority = false
                },
                new Store_Menu
                {
                    StoreId = Guid.Parse("6507B7DB-7255-4274-87A4-6E2DC3D8A3C4"),
                    MenuId = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ApplyDate = "Thursday",
                    Priority = false
                }
                ,
                new Store_Menu
                {
                    StoreId = Guid.Parse("D3599DF7-877E-41C7-832D-14850E5C88BD"),
                    MenuId = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    ApplyDate = "Monday",
                    Priority = false
                },
                new Store_Menu
                {
                    StoreId = Guid.Parse("2F3EEE35-1B8E-43AF-956F-EACD94EEA7CD"),
                    MenuId = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    ApplyDate = "Monday",
                    Priority = false
                },
                new Store_Menu
                {
                    StoreId = Guid.Parse("70C6A937-F285-4495-8407-B20A0C9B10F3"),
                    MenuId = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    ApplyDate = "Monday",
                    Priority = false
                },
                new Store_Menu
                {
                    StoreId = Guid.Parse("EF443E4B-886C-4C06-8528-51E9CF623867"),
                    MenuId = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    ApplyDate = "Monday",
                    Priority = false
                }
            );
        }
    }
}
