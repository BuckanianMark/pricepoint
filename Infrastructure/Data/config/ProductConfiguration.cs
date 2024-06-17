using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure
        (EntityTypeBuilder<Product> builder)
        {
           builder.Property(p => p.Id).IsRequired();
           builder.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
           builder.Property(p => p.Description).IsRequired().HasMaxLength(10000);
         
        }
    }
}