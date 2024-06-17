using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace product_catalog_api.Model.Domain
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } 
        public List<string> ProductSpecs { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ProductImage { get; set; }
        [NotMapped]
        public IFormFile?  ImageFile { get; set; }
        // [Required]
        public  ProductType ProductType { get; set; }
        
        public int ProductTypeId { get; set; }
        // [Required]
        public  ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
        public bool Latest { get; set; }
    }
}