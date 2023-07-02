using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class GetBrandById : GetBaseItemById<Domain.Brand,BaseDto>
{
    public GetBrandById(int id) : base(id)
    {
        
    }
}

public class GetBrandByIdHandler : GetBaseItemByIdHandler<Domain.Brand, BaseDto>
{
    public GetBrandByIdHandler(IBrandRepo repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
