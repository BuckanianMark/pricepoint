using API.Dtos;

namespace API.AddProductInterface
{
    public interface IAddProduct
    {
        public Tuple<int,string> SaveImage(IFormFile imagefile);
        Task<bool> Add(ProductToAddDto model);
    }
}