using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Entity.Basket;
using UgeElectronics.Core.Entity.Order_Aggregation;

namespace Sales_System.Repository.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Categorys) // Define relationship to Category
                .WithMany(c => c.Products) // Define reverse relationship to List of Products
                .HasForeignKey(p => p.CategoryId) // Define CategoryId as the foreign key
                .OnDelete(DeleteBehavior.Cascade); // Set delete behavior
                                                   // تحديد ProductItemsOrder ككائن غير مملوك (keyless)
     

        }

        // Define DbSets for the entities
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BasketItems> BasketItems { get; set; }
        public DbSet<Deliverymethod> Deliverymethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerBasket> CustomerBaskets { get; set; }
    }
}
