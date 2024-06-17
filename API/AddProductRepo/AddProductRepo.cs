using API.AddProductInterface;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



namespace API.AddProductRepo
{
    public class AddProductRepo : IAddProduct
    {
        private IWebHostEnvironment _enviroment;
        private readonly StoreContext _context;
        private readonly IMapper _mapper;
        public AddProductRepo(IWebHostEnvironment enviroment,StoreContext context,IMapper mapper)
        {
                _enviroment = enviroment;
                 _context = context; 
                _mapper = mapper;
        }

      
        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var contentPath = _enviroment.ContentRootPath;
                var path = Path.Combine(contentPath,"Uploads");
                  if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                     var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] {".jpeg",".png",".jpg"};
                if(!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions allowed", string.Join(",",allowedExtensions));
                    return new Tuple<int, string>(0,msg);
                }
                                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path,newFileName);
                var stream = new FileStream(fileWithPath,FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int,string>(1,newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0,"Error has occured");
            }
        }

        public Task<bool> Add(ProductToAddDto model)
        {
            throw new NotImplementedException();
        }
    }
}