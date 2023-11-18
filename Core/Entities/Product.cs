


namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        public List<Specs>? Specs { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }
        public string? PictureUrl { get; set; }
        public ProductType? ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand? ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
        public bool Latest { get; set; }
        
    }

  
}