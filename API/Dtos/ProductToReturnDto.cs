using Core.Entities;

namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } 
        public List<string> ProductSpecs { get; set; } 
        public string Description { get; set; }
        public string Price { get; set; }
        public string PictureUrl { get; set; }
        public required string ProductType { get; set; }
        public required string ProductBrand { get; set; }
        public bool Latest { get; set; }
        
    }
}