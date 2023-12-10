using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasData(
                new Station
                {
                    Id = Guid.Parse("50CB67F8-421E-4AEC-85ED-7114E763D6C4"),
                    StationName = "Ga Metro Bến Thành",
                    StoreID = Guid.Parse("AA2610A8-DE94-42B7-B12B-1CF8710E05D8")
                },
                new Station
                {
                    Id = Guid.Parse("50CB67F8-421E-4AEC-85ED-7114E763D6C5"),
                    StationName = "Ga Metro Vincom Bình Thạnh",
                    StoreID = Guid.Parse("D3599DF7-877E-41C7-832D-14850E5C88BD")
                },
                new Station
                {
                    Id = Guid.Parse("50CB67F8-421E-4AEC-85ED-7114E763D6C6"),
                    StationName = "Ga Metro Chợ Thủ Đức",
                    StoreID = Guid.Parse("2F3EEE35-1B8E-43AF-956F-EACD94EEA7CD")
                },
                new Station
                {
                    Id = Guid.Parse("50CB67F8-421E-4AEC-85ED-7114E763D6C7"),
                    StationName = "Ga Metro Khu Công Nghệ Cao",
                    StoreID = Guid.Parse("70C6A937-F285-4495-8407-B20A0C9B10F3")
                },
                new Station
                {
                    Id = Guid.Parse("50CB67F8-421E-4AEC-85ED-7114E763D6C8"),
                    StationName = "Ga Metro Suối Tiên",
                    StoreID = Guid.Parse("EF443E4B-886C-4C06-8528-51E9CF623867")
                },
                new Station
                {
                    Id = Guid.Parse("50CB67F8-421E-4AEC-85ED-7114E763D6C9"),
                    StationName = "Ga Metro Bến xe Miền Đông",
                    StoreID = Guid.Parse("6507B7DB-7255-4274-87A4-6E2DC3D8A3C4")
                });
        }
    }


}
