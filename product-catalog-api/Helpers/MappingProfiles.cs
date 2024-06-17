using AutoMapper;
using product_catalog_api.Model.Domain;
using product_catalog_api.Model.Dto;

namespace product_catalog_api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductToAddDTO,Product>();
            
        }
    }
}