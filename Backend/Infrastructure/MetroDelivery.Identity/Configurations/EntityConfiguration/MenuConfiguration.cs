using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasData(
                // data này đang giả định, chưa đưa về để sử dụng chung với store của station, nếu menu nào thuộc sân ga trong tuyến q1 đến bx miền thì lấy cái menu ở dưới
                new Menu
                {
                    Id = Guid.Parse("E7A15238-5DB0-49BD-94E6-D5F8B77AE6CE"),
                    MenuName = "Bữa sáng 1",
                    StartTimeService = TimeSpan.Parse("06:00"),
                    EndTimeService = TimeSpan.Parse("13:00")
                },
                new Menu
                {
                    Id = Guid.Parse("5263453C-DAE9-45E4-8204-5430A7256CDE"),
                    MenuName = "Bữa chiều 1",
                    StartTimeService = TimeSpan.Parse("13:00"),
                    EndTimeService = TimeSpan.Parse("22:00")
                },
                new Menu
                {
                    Id = Guid.Parse("D3FD2009-C658-4498-BF59-26936918A0C8"),
                    MenuName = "Bữa chiều 2",
                    StartTimeService = TimeSpan.Parse("13:00"),
                    EndTimeService = TimeSpan.Parse("22:00")
                }

            );
        }
    }
}
