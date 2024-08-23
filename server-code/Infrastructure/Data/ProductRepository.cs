
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository 
    {
        private readonly StoreContext _context;
       
  
        public ProductRepository(StoreContext context)
        {
            _context = context;
            
         
        }

       

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
          
            var products = await _context.Products
            .ToListAsync();

            return products;
      
        }
         public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
            return await _context.ProductBrands.ToListAsync();
        }

        // public async Task<IReadOnlyList<ProductSpecs>> GetProductSpecsAsync()
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
             return await _context.ProductTypes.ToListAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
             await _context.Products.AddAsync(product);
             await _context.SaveChangesAsync();
             return product;
        }

        public async Task<ProductBrand> AddProductBrandAsync(ProductBrand productBrand)
        {
            await _context.ProductBrands.AddAsync(productBrand);
            await _context.SaveChangesAsync();
            return productBrand;
        }

        public async Task<ProductType> AddProductTypeAsync(ProductType productType)
        {
            await _context.ProductTypes.AddAsync(productType);
            await _context.SaveChangesAsync();
            return productType;
        }

        // public async Task<string> RemoveProductAsync(int productId)
        // {
        //     try
        //     {
        //              var productToDelete = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        //    if(productToDelete != null)
        //    {
        //     _context.Products.Remove(productToDelete);
        //     await _context.SaveChangesAsync();
        //     return productToDelete.PictureUrl;
        //    }
        //    return string.Empty; 
        //     }
        //     catch (System.Exception)
        //     {
                
        //         throw;
        //     }
     
        // }


        public Task UpdateProductAsync(int productId, Product product)
        {
            throw new NotImplementedException();
        }

        // public async Task<ProductSpecs> AddSpecs(int productId, List<ProductSpecs> specs)
        // {
        //    await _context.Products.FindAsync(productId);
        //    await _context.Products.
        // }
    }
}