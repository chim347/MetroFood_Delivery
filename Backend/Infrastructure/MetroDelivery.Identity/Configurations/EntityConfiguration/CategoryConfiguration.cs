using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = Guid.Parse("9AFCDFAC-1A27-496B-84E5-0C8E5804E40E"),
                    CategoryName = "Food",
                },
                //Thuc uong
                new Category
                {
                    Id = Guid.Parse("4078EF19-BA53-481D-9C5A-1C37DFE0E0DC"),
                    CategoryName = "Beverages",
                },
                //Banh mi
                new Category
                {
                    Id = Guid.Parse("B7A3A853-73C6-4F02-913B-9765019E9BD0"),
                    CategoryName = "Bread",
                },
                new Category

                {
                    Id = Guid.Parse("175D4C8D-D2F0-441B-85CB-45A1CB0B6756"),
                    CategoryName = "Candy",
                },
                //Khoai tay chien
                new Category
                {
                    Id = Guid.Parse("8908EA98-B421-420B-9634-03ED356BB921"),
                    CategoryName = "Chips",

                },
                new Category
                {
                    Id = Guid.Parse("9B2CCCB2-F5FA-4358-8265-0FE4F7A52253"),
                    CategoryName = "Cookies",
                },
                //San pham lam tu sua
                new Category
                {
                    Id = Guid.Parse("39696F0C-2C8A-480F-B917-141B7DA708E4"),
                    CategoryName = "Dairy",
                }
                );
        }
    }

}
