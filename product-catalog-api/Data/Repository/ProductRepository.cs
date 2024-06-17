using product_catalog_api.Data.Interface;
using product_catalog_api.Model.Dto;
using product_catalog_api.Data;
using AutoMapper;
using product_catalog_api.Model.Domain;

namespace product_catalog_api.Data.Repository
{
    public class ProductRepository: IProduct
    {
        private readonly MyDbContext _context;
         private readonly IMapper _mapper;
        public ProductRepository(MyDbContext context,IMapper mapper)
        {
             _context = context; 
             _mapper = mapper;
        }
  	   public async Task<bool> Add(ProductToAddDTO model)
        {
            try
            {
                var product = _mapper.Map<Product>(model);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
        
        
        //  var productType = await _context.ProductTypes.FindAsync(model.ProductTypeId);
        //  var productBrand = await _context.ProductBrands.FindAsync(model.ProductBrandId);
        
        //   if (productType == null || productBrand == null)
        //   {
        //     throw new Exception("ProductType or ProductBrand not found.");
        //   }

      
        // model.ProductType = productType;
        // model.ProductBrand = productBrand;
        
   
        await _context.SaveChangesAsync();
        
          return true;
          } 
            catch (System.Exception)
            {
                return false;
            }
       }
    }
}