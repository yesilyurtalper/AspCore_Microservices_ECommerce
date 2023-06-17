﻿using AutoMapper;
using ECommerce.ItemService.Application.Dtos;
using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.MappingProfiles;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<BrandCategory, BCBaseDto>().ReverseMap();

        CreateMap<Brand, BrandDto>()
            .ForMember(dto => dto.ProductBaseDtos, opt => opt.MapFrom(model => model.Products))
            .ForMember(dto => dto.BCBaseDtos, opt => opt.MapFrom(model => model.BrandCategories))
            .AfterMap((model, dto) =>
            {
                if (model.BrandCategories is not null)
                {
                    dto.CategoryBaseDtos = model.BrandCategories.Select(x => new BaseDto
                    {
                        Id = x.CategoryId,
                        Name = x.Category != null ? x.Category.Name : "",
                        Description = x.Category != null ? x.Category.Description : ""
                    })
                    .ToList();
                }
            });
        CreateMap<BrandDto, Brand>()
            .ForMember(model => model.Products, opt => opt.Ignore())
            .ForMember(model => model.BrandCategories, opt => opt.MapFrom(dto => dto.BCBaseDtos));
    }
}
