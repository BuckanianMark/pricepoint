using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.OpenApi.Expressions;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ProductImage))
            {
                return _config["ApiUrl"] + source.ProductImage;
            }
            return null;
        }
    }
}