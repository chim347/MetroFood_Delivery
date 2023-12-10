using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {   //anh da đen order
                    Id = Guid.Parse("A8AF2F67-447F-4F70-B660-4DD08FA47D4D"),
                    TotalPrice = 0,
                    OrderTokenQR = "1231212QR",
                    OrderStatus = 0,
                    ApplicationUserID = "E6DE8827-B7C2-46E9-9227-66E6ECE676A8",
                    TripID = Guid.Parse("823ad122-7b51-4dab-9d37-b0f238d4a2ff"),
                    StoreID = Guid.Parse("EF443E4B-886C-4C06-8528-51E9CF623867")
                },
                new Order
                {   // vĩ bê đê order
                    Id = Guid.Parse("D68EE4E5-980E-4EC7-8060-DF214D458C79"),
                    TotalPrice = 0,
                    OrderTokenQR = "11789212QR",
                    OrderStatus = 0,
                    ApplicationUserID = "E6DE8827-B7C2-46E9-9227-66E6ECE676A8",
                    TripID = Guid.Parse("9c2ab923-4c57-44d7-9c1a-b44c0d3e6b00"),
                    StoreID = Guid.Parse("AA2610A8-DE94-42B7-B12B-1CF8710E05D8")
                },
                new Order
                {   // nhân order
                    Id = Guid.Parse("814860C5-AB72-4605-BB47-7E78C78D6FB0"),
                    TotalPrice = 0,
                    OrderTokenQR = "1231212QR",
                    OrderStatus = 0,
                    ApplicationUserID = "E6DE8827-B7C2-46E9-9227-66E6ECE676A8",
                    TripID = Guid.Parse("27421cac-1da7-4df8-9928-7fb636ca42aa"),
                    StoreID = Guid.Parse("D3599DF7-877E-41C7-832D-14850E5C88BD")
                }
            );
        }
    }
}
