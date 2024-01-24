using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductSpecs> _productSpecsRepo;

        public ProductsController(
        IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBrandRepo,
        IGenericRepository<ProductType> productTypeRepo,
        IGenericRepository<ProductSpecs> productSpecsRepo,
        IMapper mapper
        )
        {
            _mapper = mapper;
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _productSpecsRepo = productSpecsRepo;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(
            string? sort,int? brandId,int? typeId,bool latest)
        {
            var spec = new ProductsWithTypesBrandsAndSpecsSpecification(sort,brandId,typeId,latest);
            
            var products = await _productsRepo.ListAsync(spec);
            
            return Ok(_mapper.Map<IReadOnlyList<Product> , IReadOnlyList<ProductToReturnDto>>(products));
            
            
        }
        // public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetLatestProducts(string sort)
        // {
        //     return
        // }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id){
            var spec = new ProductsWithTypesBrandsAndSpecsSpecification(id);
            
            var product = await _productsRepo.GetEntityWithSpec(spec);
            if(product == null) return NotFound();
     
            return _mapper.Map<Product , ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
          [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypess()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
          [HttpGet("specs")]
        public async Task<ActionResult<IReadOnlyList<ProductSpecs>>> GetProductSpecs()
        {
            return Ok(await _productSpecsRepo.ListAllAsync());
        }
    }
}