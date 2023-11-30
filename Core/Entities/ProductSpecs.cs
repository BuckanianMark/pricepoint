
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ProductSpecs : BaseEntity
    {
        public string? Spec { get; set; }
        public int  ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}