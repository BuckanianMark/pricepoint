using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.config
{
    public class ProductItemOrderdConfiguration : IEntityTypeConfiguration<ProductItemOrdered>
    {
        public void Configure(EntityTypeBuilder<ProductItemOrdered> builder)
        {
            builder.HasNoKey();
        }
    }
}