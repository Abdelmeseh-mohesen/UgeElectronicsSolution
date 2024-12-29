using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UgeElectronics.Core.Entity;

namespace UgeElectronics.Repositry.Data.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Navigation(c => c.Categorys).AutoInclude(false);

        }
    }
}
