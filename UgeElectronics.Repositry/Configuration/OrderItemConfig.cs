using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UgeElectronics.Core.Entity.Order_Aggregation;

namespace UgeElectronics.Repositry.Configuration
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(oi => oi.product, product => product.WithOwner()); // 1 to 1 
            builder.Property(oi => oi.price)
              .HasColumnType("decimal(18,2)");

        }
    }
}
