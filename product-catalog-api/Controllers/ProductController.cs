using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using product_catalog_api.Data.Interface;
using  product_catalog_api.Model.Dto;
using product_catalog_api.Model.Dto;

namespace product_catalog_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IProduct _productRepo;
        public ProductController(IFileService fileService,IProduct productRepo)
        {
            _fileService = fileService;
            _productRepo = productRepo;
        }
        [HttpPost("Add Product")]
        public async Task<IActionResult> AddProduct([FromForm] ProductToAddDTO model)
        {
            var status = new Status();
              if(!ModelState.IsValid)
            {
              status.StatusCode = 0;
              status.Message = "Please pass valid data";
               return Ok(status);
            }
            try
            {
             if(model.ImageFile != null)
            {
              var result = _fileService.SaveImage(model.ImageFile);
              if(result.Item1 == 1)
              {
                model.ProductImage = result.Item2;
              }
               else
             {
                 status.StatusCode = 0;
                 status.Message = "Error saving image";
                 return Ok(status);
             }
            }  
            else
            {
                 status.StatusCode = 0;
                 status.Message = "Image file is required";
                 return Ok(status);
            }

              var productResult = await _productRepo.Add(model);
              if(productResult)
              {
                status.StatusCode = 1;
                status.Message = "Added successfully";
              }
              else{
                status.StatusCode = 0;
                status.Message = "Error adding a product";
              }
              return Ok(status);
            }
                catch (Exception ex)
                {
                     return StatusCode(StatusCodes.Status500InternalServerError, new Status
                {
                    StatusCode = 500,
                    Message = ex.Message
                });
                }
        }
        
    }
}