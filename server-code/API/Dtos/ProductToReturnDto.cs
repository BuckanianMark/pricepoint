using Core.Entities;

namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } 
        public List<string> ProductSpecs { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public required string ProductType { get; set; }
        public required string ProductBrand { get; set; }
        public bool Latest { get; set; }
        
    }
}