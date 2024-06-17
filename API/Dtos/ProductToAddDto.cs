using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace API.Dtos
{
    public class ProductToAddDto
    {
         public string ProductName { get; set; } 
        public List<string> ProductSpecs { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ProductImage { get; set; }
        [NotMapped]
        public IFormFile?  ImageFile { get; set; }
        
        public int ProductTypeId { get; set; } 

        public int ProductBrandId { get; set; }

        public bool Latest { get; set; }
    }
}