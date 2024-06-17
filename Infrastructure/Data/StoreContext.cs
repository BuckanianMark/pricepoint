using System.Reflection;
using System.Text.Json;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {
        }

        public DbSet<Product> Products {get;set;}
        public DbSet<ProductBrand> ProductBrands {get;set;}
        public DbSet<ProductType> ProductTypes {get;set;}
        // public DbSet<Order> Orders { get; set; }
        // public DbSet<OrderItem> OrderItems { get; set; }
        // // public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .Property(p => p.ProductSpecs)
                        .HasConversion(
                            v => JsonSerializer.Serialize(v,new JsonSerializerOptions{WriteIndented = false}),
                            v => JsonSerializer.Deserialize<List<string>>(v,new JsonSerializerOptions { PropertyNameCaseInsensitive = true }));
                        
            base.OnModelCreating(modelBuilder);
            
        }

    }


}