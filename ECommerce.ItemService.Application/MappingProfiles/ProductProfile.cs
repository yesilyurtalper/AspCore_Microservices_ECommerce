using AutoMapper;
using ECommerce.ItemService.Application.Dtos;
using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.MappingProfiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductBaseDto>().ReverseMap();

            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.BrandBaseDto, opt => opt.MapFrom(model => model.Brand))
                .ForMember(dto => dto.CategoryBaseDto, opt => opt.MapFrom(model => model.Category));
            CreateMap<ProductDto, Product>()
                .ForMember(model => model.Brand, opt => opt.Ignore())
                .ForMember(model => model.Category, opt => opt.Ignore());
        }
    }
}
