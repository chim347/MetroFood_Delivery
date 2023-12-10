using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(
                new Store
                {
                    Id = Guid.Parse("AA2610A8-DE94-42B7-B12B-1CF8710E05D8"),
                    StoreLocation = "Số 2, Đường Lê Lai, Quận 1",
                    StoreName = "Metro PickUp 1",
                    StoreOpenTime = TimeSpan.Parse("06:00"),
                    StoreCloseTime = TimeSpan.Parse("23:00"),

                },
                new Store
                {
                    Id = Guid.Parse("D3599DF7-877E-41C7-832D-14850E5C88BD"),
                    StoreLocation = "Số 3, Vincom, Quận Bình Thạnh",
                    StoreName = "Metro PickUp 2",
                    StoreOpenTime = TimeSpan.Parse("06:00"),
                    StoreCloseTime = TimeSpan.Parse("06:00"),
                },
                new Store
                {
                    Id = Guid.Parse("2F3EEE35-1B8E-43AF-956F-EACD94EEA7CD"),
                    StoreLocation = "Số 1, Võ Văn Ngân, Thành Phố Thủ Đức",
                    StoreName = "Metro PickUp 3",
                    StoreOpenTime = TimeSpan.Parse("06:00"),
                    StoreCloseTime = TimeSpan.Parse("06:00"),
                },
                 new Store
                 {
                     Id = Guid.Parse("70C6A937-F285-4495-8407-B20A0C9B10F3"),
                     StoreLocation = "Khu Công Nghệ Cao Thành Phố Thủ Đức ",
                     StoreName = "Metro PickUp 4",
                     StoreOpenTime = TimeSpan.Parse("06:00"),
                     StoreCloseTime = TimeSpan.Parse("06:00"),
                 },
                 new Store
                 {
                     Id = Guid.Parse("EF443E4B-886C-4C06-8528-51E9CF623867"),
                     StoreLocation = "Suối tiên",
                     StoreName = "Metro PickUp 5",
                     StoreOpenTime = TimeSpan.Parse("06:00"),
                     StoreCloseTime = TimeSpan.Parse("06:00"),
                 },
                 new Store
                 {
                     Id = Guid.Parse("6507B7DB-7255-4274-87A4-6E2DC3D8A3C4"),
                     StoreLocation = "Bến Xe Miền Đông",
                     StoreName = "Metro PickUp 6",
                     StoreOpenTime = TimeSpan.Parse("06:00"),
                     StoreCloseTime = TimeSpan.Parse("06:00"),
                 }
                );
        }
    }


}
