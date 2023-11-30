
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        protected MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>();
        }
    }
}