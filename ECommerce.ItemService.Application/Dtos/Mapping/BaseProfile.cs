using AutoMapper;
using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.Dtos.Mapping;

public class BaseProfile : Profile
{
    public BaseProfile()
    {
        CreateMap<BaseItem, BaseDto>();

        CreateMap<BaseDto, BaseItem>().
            ForMember(model => model.CreatedBy, opt => opt.Ignore()).
            ForMember(model => model.ModifiedBy, opt => opt.Ignore()).
            ForMember(model => model.DateCreated, opt => opt.Ignore()).
            ForMember(model => model.DateModified, opt => opt.Ignore());
    }
}
