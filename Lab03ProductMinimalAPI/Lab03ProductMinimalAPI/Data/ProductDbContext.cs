using Lab03ProductMinimalAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab03ProductMinimalAPI.Data
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options) {

            this.Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                 new Product { Id=1,Name="Samsung SmartTV",IsAvailable=true,Price=500 },
                                  new Product { Id = 2, Name = "Hp Laptop", IsAvailable = true, Price = 100 },
                                  new Product { Id = 3, Name = "OnePlus", IsAvailable = false, Price = 50 }

                );
        }

    }
}
