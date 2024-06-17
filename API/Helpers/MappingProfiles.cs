
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            
            // CreateMap<ProductToAddDto, Product>()
            //     .ForMember(d => d.ProductType, o => o.MapFrom(src => new ProductType { Name = src.ProductType }))
            // .ForMember(d => d.ProductBrand, o => o.MapFrom(src => new ProductBrand { Name = src.ProductBrand }));
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.ProductImage, o => o.MapFrom<ProductUrlResolver>());
            // CreateMap<ProductToAddDto,Product>()
            //        .ForMember(d => d.ProductType, o => o.MapFrom(src => new ProductType { Name = src.ProductType }))
            // .ForMember(d => d.ProductBrand, o => o.MapFrom(src => new ProductBrand { Name = src.ProductBrand }))
            //        .ReverseMap();
            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto,CustomerBasket>();
            CreateMap<BasketItemDto,BasketItem>();
            CreateMap<ProductTypeToAdd,ProductType>();
            CreateMap<ProductBrandToAdd,ProductBrand>();
            CreateMap<AddressDto,Core.Entities.OrderAggregate.Address>();
        }

    }
}