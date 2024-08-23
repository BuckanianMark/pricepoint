using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        // Task<bool> Add(ProductToAdd model);
        // Task<string> RemoveProductAsync(int productId);
        Task UpdateProductAsync(int productId,Product product);
        Task<ProductType> AddProductTypeAsync(ProductType productType);
        //Task<ProductSpecs> AddSpecs(int productId,List<ProductSpecs> specs);
        Task<ProductBrand> AddProductBrandAsync(ProductBrand productBrand);
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        // Task<IReadOnlyList<ProductSpecs>> GetProductSpecsAsync();
        
    }
}