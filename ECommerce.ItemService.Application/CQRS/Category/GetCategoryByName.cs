using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class GetCategoryByName : GetBaseItemByName<Domain.Category,BaseDto>
{
    public GetCategoryByName(string name) : base (name)
    {
        
    }
}

public class GetCategoryByNameHandler : GetBaseItemByNameHandler<Domain.Category, BaseDto>
{
    public GetCategoryByNameHandler(ICategoryRepo repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
