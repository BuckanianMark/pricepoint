

namespace product_catalog_api.Data.Interface
{
    public interface IFileService
    {
        public Tuple<int,string> SaveImage(IFormFile imagefile);
        // public Tuple DeleteImage(string imagefile);
    }
}