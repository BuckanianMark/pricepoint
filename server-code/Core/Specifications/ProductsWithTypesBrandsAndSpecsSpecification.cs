
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesBrandsAndSpecsSpecification : BaseSpecification<Product>
    {
     

        public ProductsWithTypesBrandsAndSpecsSpecification(string? sort,int? brandId,int? typeId, bool latest) 
        : base ( x =>
            (!brandId.HasValue || x.ProductBrandId == brandId) &&
            (!typeId.HasValue || x.ProductTypeId == typeId) && 
            (!latest == true)) 
        {
             AddInclude(x => x.ProductType); 
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.ProductName);
              if(!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break; 
                    default:
                        AddOrderBy(n => n.ProductName);
                    break;
                }
            }
            

        }

        
        public ProductsWithTypesBrandsAndSpecsSpecification(int id) 
        : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

      
    }
}