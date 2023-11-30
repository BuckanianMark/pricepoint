
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesBrandsAndSpecsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesBrandsAndSpecsSpecification()  
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
             AddInclude(x => x.ProductSpecs);
            

        }

        
        public ProductsWithTypesBrandsAndSpecsSpecification(int id) 
        : base(x => x.Id == id)
        {
           
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductSpecs);
        }

      
    }
}