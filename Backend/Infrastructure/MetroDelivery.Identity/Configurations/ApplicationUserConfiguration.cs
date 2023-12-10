using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace MetroDelivery.Identity.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "2198E4CD-3305-49C5-B78A-0B54DD76898F",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    FirstName = "Nhan",
                    LastName = "Admin",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true,
                    Address = "da nang",
                    Birthday = DateTime.ParseExact("20/10/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PhoneNumber = "03030303",
                    Wallet = null,
                },
                new ApplicationUser
                {
                    Id = "E6DE8827-B7C2-46E9-9227-66E6ECE676A8",
                    Email = "enduser@gmail.com",
                    NormalizedEmail = "ENDUSER@GMAIL.COM",
                    FirstName = "Vi",
                    LastName = "EndUser",
                    UserName = "enduser@gmail.com",
                    NormalizedUserName = "ENDUSER@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true,
                    PhoneNumber = "03030303",
                    Address = "hcm",
                    Birthday = DateTime.ParseExact("04/03/2010", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Wallet = null,
                },
                new ApplicationUser
                {
                    Id = "2C0B43BB-B991-408E-A8F3-2FD3B4A2AB84",
                    Email = "staff@gmail.com",
                    NormalizedEmail = "STAFF@GMAIL.COM",
                    FirstName = "Vi",
                    LastName = "Staff",
                    UserName = "staff@gmail.com",
                    NormalizedUserName = "STAFF@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true,
                    PhoneNumber = "0961868641",
                    Address = "Cần Thơ",
                    Birthday = DateTime.ParseExact("04/05/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Wallet = null,
                    StoreId = Guid.Parse("2f3eee35-1b8e-43af-956f-eacd94eea7cd")
                },

                // manager
                new ApplicationUser
                {
                    Id = "2E089AF6-3437-4DD6-9956-BB792E783AFB",
                    Email = "nguyenthanhn537@gmail.com",
                    NormalizedEmail = "NGUYENTHANHN537@GMAIL.COM",
                    FirstName = "Nhân",
                    LastName = "Nguyễn",
                    UserName = "nguyenthanhn537@gmail.com",
                    NormalizedUserName = "NGUYENTHANHN537@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true,
                    PhoneNumber = "0903182861",
                    Address = "Đắk Lắk",
                    Birthday = DateTime.ParseExact("14/08/1899", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Wallet = null,
                    StoreId = Guid.Parse("ef443e4b-886c-4c06-8528-51e9cf623867"),
                },
                new ApplicationUser
                {
                    Id = "1F11BA64-2870-43F7-BB03-867112867F25",
                    Email = "thaivin537@gmail.com",
                    NormalizedEmail = "THAIVIN537@GMAIL.COM",
                    FirstName = "Thái",
                    LastName = "Vĩ",
                    UserName = "thaivin537@gmail.com",
                    NormalizedUserName = "THAIVIN537@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true,
                    PhoneNumber = "0914009910",
                    Address = "Gia Lai",
                    Birthday = DateTime.ParseExact("26/02/1998", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Wallet = null
                },
                new ApplicationUser
                {
                    Id = "C4EE82A1-DB88-49A6-81A8-4B9521FF01F9",
                    Email = "anhjenda537@gmail.com",
                    NormalizedEmail = "ANHJENDA537@GMAIL.COM",
                    FirstName = "Anh",
                    LastName = "Da Đen",
                    UserName = "anhjenda537@gmail.com",
                    NormalizedUserName = "ANHJENDA537@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    Address = "Kon Tum",
                    Birthday = DateTime.ParseExact("26/02/1998", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Wallet = null,
                },
                new ApplicationUser
                {
                    Id = "DB903C85-4C75-428B-A7B0-9B56130F4813",
                    Email = "dungho537@gmail.com",
                    NormalizedEmail = "DUNGHO537@GMAIL.COM",
                    FirstName = "Dũng",
                    LastName = "Hồ",
                    UserName = "dungHo537@gmail.com",
                    NormalizedUserName = "DUNGHO537@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    Address = "Đồng Nai",
                    Birthday = DateTime.ParseExact("26/02/1998", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Wallet = null,
                },
                new ApplicationUser
                {
                    Id = "8E48858E-7089-4512-BB79-75AEDC2003D6",
                    Email = "vinhttran537@gmail.com",
                    NormalizedEmail = "VINHTTRAN537@GMAIL.COM",
                    FirstName = "Vinh",
                    LastName = "Trần",
                    UserName = "vinhtran537@gmail.com",
                    NormalizedUserName = "VINHTRAN537@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    Address = "Suối Tiên",
                    Birthday = DateTime.ParseExact("26/02/1998", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Wallet = null,
                },

                // end user
                new ApplicationUser
                {
                    Id = "B76C9C1E-7F7F-4175-93B3-39B1285F0E71",
                    Email = "nguyentrieu537@gmail.com",
                    NormalizedEmail = "NGUYENTRIEU537@GMAIL.COM",
                    FirstName = "Nguyên",
                    LastName = "Triệu",
                    UserName = "nguyentrieu537@gmail.com",
                    NormalizedUserName = "NGUYENTRIEU537@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    Address = "Tây NGuyên",
                    Birthday = DateTime.ParseExact("26/02/1998", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Wallet = 123456789
                }
            );
        }
    }
}
