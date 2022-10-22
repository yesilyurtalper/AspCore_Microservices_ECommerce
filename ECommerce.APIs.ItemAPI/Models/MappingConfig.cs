using AutoMapper;

namespace ECommerce.APIs.ItemAPI.Models
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var config = new MapperConfiguration(config =>
                {
                    config.CreateMap<BaseModel, BaseDto>().ReverseMap();
                    config.CreateMap<BrandCategory, BCBaseDto>().ReverseMap();
                    config.CreateMap<Product, ProductBaseDto>().ReverseMap();

                    config.CreateMap<Brand, BrandDto>()
                    .ForMember(dto => dto.ProductBaseDtos, opt => opt.MapFrom(model => model.Products))
                    .ForMember(dto => dto.BCBaseDtos, opt => opt.MapFrom(model => model.BrandCategories))
                    .AfterMap((model, dto) =>
                    {
                        if (model.BrandCategories is not null)
                        {
                            dto.CategoryBaseDtos = model.BrandCategories.Select(x=> new BaseDto {
                                    Id = x.CategoryId,
                                    Name = x.Category != null ? x.Category.Name : "",
                                    Description = x.Category != null ? x.Category.Description : ""
                                })
                            .ToList();
                        }
                    });
                    config.CreateMap<BrandDto, Brand>()
                    .ForMember(model => model.Products, opt => opt.Ignore())
                    .ForMember(model => model.BrandCategories, opt => opt.MapFrom(dto => dto.BCBaseDtos));

                    config.CreateMap<Category, CategoryDto>()
                    .ForMember(dto => dto.ProductBaseDtos, opt => opt.MapFrom(model => model.Products))
                    .ForMember(dto => dto.BCBaseDtos, opt => opt.MapFrom(model => model.BrandCategories))
                    .AfterMap((model, dto) =>
                    {
                        if (model.BrandCategories is not null)
                        {
                            dto.BrandBaseDtos = model.BrandCategories.Select(x => new BaseDto
                            {
                                Id = x.BrandId,
                                Name = x.Brand != null ? x.Brand.Name : "",
                                Description = x.Brand != null ? x.Brand.Description : ""
                            })
                            .ToList();
                        }
                    });
                    config.CreateMap<CategoryDto, Category>()
                    .ForMember(model => model.Products, opt => opt.Ignore())
                    .ForMember(model => model.BrandCategories, opt => opt.Ignore());

                    config.CreateMap<Product, ProductDto>()
                    .ForMember(dto => dto.BrandBaseDto, opt => opt.MapFrom(model => model.Brand))
                    .ForMember(dto => dto.CategoryBaseDto, opt => opt.MapFrom(model => model.Category));               
                    config.CreateMap<ProductDto, Product>()
                    .ForMember(model => model.Brand, opt => opt.Ignore())
                    .ForMember(model => model.Category, opt => opt.Ignore());
                }
            );

            return config;
        }
    }
}
