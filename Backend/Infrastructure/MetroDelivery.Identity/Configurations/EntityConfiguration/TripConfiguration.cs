using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasData(
            new Trip
            {
                Id = Guid.Parse("823ad122-7b51-4dab-9d37-b0f238d4a2ff"),
                TripName = "Camping Trip",
                TripStartTime = DateTime.Parse("7/15/2023 8:00 AM"),
                TripEndTime = DateTime.Parse("7/17/2023 12:00 PM"),
                RouteId = Guid.Parse("EA675490-EECD-4308-BB71-61B72A9C979F")
            },
            new Trip
            {
                Id = Guid.Parse("9c2ab923-4c57-44d7-9c1a-b44c0d3e6b00"),
                TripName = "Road Trip",
                TripStartTime = DateTime.Parse("5/20/2023 9:00 AM"),
                TripEndTime = DateTime.Parse("5/25/2023 8:00 PM"),
                RouteId = Guid.Parse("001A254C-02D4-40E7-A01F-95F393FB41EF")
            },
            new Trip
            {
                Id = Guid.Parse("02859382-d88c-4e69-8c47-b8e0456677d5"),
                TripName = "Cruise Vacation",
                TripStartTime = DateTime.Parse("9/10/2023 9:00 AM"),
                TripEndTime = DateTime.Parse("9/15/2023 1:00 PM"),
                RouteId = Guid.Parse("A437B242-55FC-4146-A2B9-8C952B107E3A")
            },
            new Trip
            {
                Id = Guid.Parse("27421cac-1da7-4df8-9928-7fb636ca42aa"),
                TripName = "Hiking Adventure",
                TripStartTime = DateTime.Parse("11/12/2023 9:00 AM"),
                TripEndTime = DateTime.Parse("11/14/2023 5:00 PM"),
                RouteId = Guid.Parse("CCC66514-0597-4D43-AAFF-0C5D8EE59FFA")
            },
            new Trip
            {
                Id = Guid.Parse("5b30c4e9-31ab-456c-b212-dc6b2ba9a3e7"),
                TripName = "Ski Getaway",
                TripStartTime = DateTime.Parse("12/20/2023 8:00 AM"),
                TripEndTime = DateTime.Parse("12/23/2023 2:00 PM"),
                RouteId = Guid.Parse("001A254C-02D4-40E7-A01F-95F393FB41EF")
            },
            new Trip
            {
                Id = Guid.Parse("9b4d232c-0fda-4ec0-beed-ecd649ee9c52"),
                TripName = "Tropical Vacation",
                TripStartTime = DateTime.Parse("8/13/2023 11:00 AM"),
                TripEndTime = DateTime.Parse("8/18/2023 9:00 PM"),
                RouteId = Guid.Parse("42F184EB-58B3-4B9B-BE52-1DA57F8FFB3F")
            },
            new Trip
            {
                Id = Guid.Parse("bf736039-33e9-466f-ac4e-78c89f3317e6"),
                TripName = "Amusement Park Fun",
                TripStartTime = DateTime.Parse("7/4/2023 9:00 AM"),
                TripEndTime = DateTime.Parse("7/6/2023 11:00 PM"),
                RouteId = Guid.Parse("A437B242-55FC-4146-A2B9-8C952B107E3A")
            },
            new Trip
            {
                Id = Guid.Parse("8a2ba7d5-7019-49c6-a47d-ab0a072e7932"),
                TripName = "African Safari",
                TripStartTime = DateTime.Parse("10/19/2023 7:00 AM"),
                TripEndTime = DateTime.Parse("10/19/2023 15:00 PM"),
                RouteId = Guid.Parse("B9F8F712-92EE-4611-AD55-000A8E1B84C6")
            },
            new Trip
            {
                Id = Guid.Parse("d9852f0d-e836-4a6e-94f4-d229b297933d"),
                TripName = "Botanical Gardens Tour",
                TripStartTime = DateTime.Parse("5/6/2023 1:00 PM"),
                TripEndTime = DateTime.Parse("5/8/2023 3:00 PM"),
                RouteId = Guid.Parse("A437B242-55FC-4146-A2B9-8C952B107E3A")
            }
            );
        }
    }
}
