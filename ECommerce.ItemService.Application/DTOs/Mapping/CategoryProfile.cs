﻿using AutoMapper;
using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.DTOs.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, BaseDto>();

        CreateMap<BaseDto, Category>().
            ForMember(model => model.Products, opt => opt.Ignore()).
            ForMember(model => model.BrandCategories, opt => opt.Ignore()).
            ForMember(model => model.ModifiedBy, opt => opt.Ignore()).
            ForMember(model => model.CreatedBy, opt => opt.Ignore()).
            ForMember(model => model.ModifiedBy, opt => opt.Ignore()).
            ForMember(model => model.DateCreated, opt => opt.Ignore()).
            ForMember(model => model.DateModified, opt => opt.Ignore());
        //CreateMap<Category, CategoryDto>()
        //    .ForMember(dto => dto.ProductBaseDtos, opt => opt.MapFrom(model => model.Products))
        //    .ForMember(dto => dto.BCBaseDtos, opt => opt.MapFrom(model => model.BrandCategories))
        //    .AfterMap((model, dto) =>
        //    {
        //        if (model.BrandCategories is not null)
        //        {
        //            dto.BrandBaseDtos = model.BrandCategories.Select(x => new BaseDto
        //            {
        //                Id = x.BrandId,
        //                Name = x.Brand != null ? x.Brand.Name : "",
        //                Description = x.Brand != null ? x.Brand.Description : ""
        //            })
        //            .ToList();
        //        }
        //    });
        //CreateMap<CategoryDto, Category>()
        //    .ForMember(model => model.Products, opt => opt.Ignore())
        //    .ForMember(model => model.BrandCategories, opt => opt.Ignore())
        //    .ForMember(model => model.CreatedBy, opt => opt.Ignore())
        //    .ForMember(model => model.ModifiedBy, opt => opt.Ignore())
        //    .ForMember(model => model.DateCreated, opt => opt.Ignore())
        //    .ForMember(model => model.DateModified, opt => opt.Ignore());
    }
}
