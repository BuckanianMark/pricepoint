using Microsoft.EntityFrameworkCore;
using product_catalog_api.Model.Domain;

namespace product_catalog_api.Data
{
    public class MyDbContext : DbContext
    {
      public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
      {
        
      }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        
    }
}