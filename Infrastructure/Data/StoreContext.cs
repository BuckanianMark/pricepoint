

using System.Reflection;
using Core.Entities;
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
        public DbSet<ProductSpecs> ProductSpecs { get; set; }
        public DbSet<Specs> Specs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Specs>().HasKey(s => new{
                s.ProductId,
                s.SpecId
            });
            modelBuilder.Entity<Specs>().HasOne(s => s.Product).WithMany(sp => sp.Specs).HasForeignKey(s => s.ProductId);
            modelBuilder.Entity<Specs>().HasOne(s => s.ProductSpecs).WithMany(sp => sp.Specs).HasForeignKey(s => s.SpecId);
        }

    }


}