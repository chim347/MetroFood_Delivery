using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasData(
                new Route
                {
                    Id = Guid.Parse("EA675490-EECD-4308-BB71-61B72A9C979F"),
                    FromLocation = "Quận 1, Tp.Hcm",
                    ToLocation = "Quận 9, Tp.Hcm",
                },
                new Route
                {
                    Id = Guid.Parse("001A254C-02D4-40E7-A01F-95F393FB41EF"),
                    FromLocation = "Quận 1, Tp.Hcm",
                    ToLocation = "Suối Tiên, Đồng Nai",
                },
                new Route
                {
                    Id = Guid.Parse("A437B242-55FC-4146-A2B9-8C952B107E3A"),
                    FromLocation = "Quận 1, Tp.Hcm",
                    ToLocation = "Quận Thủ Đức, Tp.Hcm",
                },
                new Route
                {
                    Id = Guid.Parse("CCC66514-0597-4D43-AAFF-0C5D8EE59FFA"),
                    FromLocation = "Quận 1, Tp.Hcm",
                    ToLocation = "Quận Bình Thạnh, Tp.Hcm",
                },
                new Route
                {
                    Id = Guid.Parse("B9F8F712-92EE-4611-AD55-000A8E1B84C6"),
                    FromLocation = "Quận 1, Tp.Hcm",
                    ToLocation = "Bến xe Miền Đông",
                },
                new Route
                {
                    Id = Guid.Parse("42F184EB-58B3-4B9B-BE52-1DA57F8FFB3F"),
                    FromLocation = "Quận Bình Thạnh",
                    ToLocation = "Bến Thành, Quận 1, TP HCM",
                }
            );
        }
    }

}
