using MetroDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroDelivery.Identity.Configurations.EntityConfiguration
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasData(
                new PaymentMethod
                {
                    Id = Guid.Parse("71B4BF27-E569-47A0-B16A-E484533BD9F2"),
                    PaymentMethodName = "thanh toán tiền mặt"
                },
                new PaymentMethod
                {
                    Id = Guid.Parse("7DB43916-E061-42CB-B0A7-9734423D00CD"),
                    PaymentMethodName = "thanh toán ngân hàng"
                },
                new PaymentMethod
                {
                    Id = Guid.Parse("47BD4DD4-3FB4-463E-B9B9-5EBFB7E1F960"),
                    PaymentMethodName = "Paypal"
                },
                new PaymentMethod
                {
                    Id = Guid.Parse("36672051-5437-4D2C-A42E-C71A9B67A2B1"),
                    PaymentMethodName = "thanh toán trên app MetroPickUp"
                }
            );
        }
    }
}
