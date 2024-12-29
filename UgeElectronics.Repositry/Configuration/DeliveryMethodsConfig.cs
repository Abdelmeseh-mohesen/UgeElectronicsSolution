using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UgeElectronics.Core.Entity.Order_Aggregation;

namespace UgeElectronics.Repositry.Configuration
{
    public class DeliveryMethodsConfig : IEntityTypeConfiguration<Deliverymethod>
    {
        public void Configure(EntityTypeBuilder<Deliverymethod> builder)
        {
            builder.Property(to => to.Cost)
                .HasColumnType("decimal(18,2)");
        }
    }
}
