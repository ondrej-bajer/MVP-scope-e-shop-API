using Microsoft.EntityFrameworkCore;
using MVP_scope_e_shop_API.Models;

namespace MVP_scope_e_shop_API.Data
{
    public class MVPScopeEshopApiContext: DbContext
    {
        public MVPScopeEshopApiContext(DbContextOptions<MVPScopeEshopApiContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "T-shirt", Brand = "Love Mountains", Color = "Red", Size = 2, Gender = "uni", Price = 250m, Description = "100% wool" },
                new Product { Id = 2, Name = "Pants", Brand = "Love Mountains", Color = "Blue", Size = 4, Gender = "male", Price = 590m, Description = "" }
                );
        }

        public DbSet<Product> Products { get; set; }

    }
}
