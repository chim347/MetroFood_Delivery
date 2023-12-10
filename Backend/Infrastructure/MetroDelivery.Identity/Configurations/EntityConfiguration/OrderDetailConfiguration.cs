using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasData(
                new OrderDetail
                {   // anh da đen
                    Id = Guid.Parse("F6D015A9-D5BB-40E8-A287-623F0AF19FC9"),
                    Price = 60000, // price of product * quantity
                    Quanity = 2,
                    ProductID = Guid.Parse("E802B6C5-F08E-4EFF-B7E7-AF95514B4341"),
                    OrderID = Guid.Parse("A8AF2F67-447F-4F70-B660-4DD08FA47D4D")
                },
                new OrderDetail
                {   // vĩ bê đê
                    Id = Guid.Parse("A8B7026D-5DEF-44EF-9666-6B78682A77CC"),
                    Price = 30000, // price of product * quantity
                    Quanity = 1,
                    ProductID = Guid.Parse("43203CE4-D82C-4C78-8794-2AEF22D7EC5B"),
                    OrderID = Guid.Parse("D68EE4E5-980E-4EC7-8060-DF214D458C79")
                },
                new OrderDetail
                {   // nhân
                    Id = Guid.Parse("05A027A2-01B0-40D2-91F7-2A33FC29753F"),
                    Price = 125000, // price of product * quantity
                    Quanity = 1,
                    ProductID = Guid.Parse("4C9EC4B9-1C16-4C7A-90BF-D620AAB257B6"),
                    OrderID = Guid.Parse("814860C5-AB72-4605-BB47-7E78C78D6FB0")
                }
            );
        }
    }
}
