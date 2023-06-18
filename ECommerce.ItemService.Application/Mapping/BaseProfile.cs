using AutoMapper;
using ECommerce.ItemService.Application.Dtos;
using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.Mapping;

public class BaseProfile : Profile
{
    public BaseProfile()
    {
        CreateMap<BaseItem, BaseDto>().ReverseMap();
    }
}
