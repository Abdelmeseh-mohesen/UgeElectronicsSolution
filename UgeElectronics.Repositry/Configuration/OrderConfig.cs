using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Entity.Order_Aggregation;

namespace UgeElectronics.Repositry.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShippingAddress, sa => sa.WithOwner()); // 1 to 1 

            builder.Property(o=>o.Status)
                .HasConversion(os=>os.ToString()
                ,os=>(OrderStatus)Enum.
                Parse(typeof(OrderStatus),os));

            builder.Property(to=>to.SubTotal)
              .HasColumnType("decimal(18,2)");


        }
    }
}
