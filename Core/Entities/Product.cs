using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; } 
        public List<ProductSpecs>? ProductSpecs { get; set; } 
        public string? Description { get; set; }
        public string? Price { get; set; }
        public string? PictureUrl { get; set; }
        public required ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public required ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
        public bool Latest { get; set; }
        
    }

  
}