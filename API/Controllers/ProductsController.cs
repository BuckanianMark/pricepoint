using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
       
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            
            var products = await _repo.GetProductsAsync();
            if(products != null){
              return Ok(products);
            }
            return BadRequest();
            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            var product = await _repo.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }
          [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypess()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
          [HttpGet("specs")]
        public async Task<ActionResult<IReadOnlyList<ProductSpecs>>> GetProductSpecs()
        {
            return Ok(await _repo.GetProductSpecsAsync());
        }
    }
}