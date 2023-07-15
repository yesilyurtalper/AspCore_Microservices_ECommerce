using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;
using Microsoft.Extensions.Logging;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class GetCategoryById : GetBaseItemById<Domain.Category,BaseDto>
{
    public GetCategoryById(int id) : base(id)
    {
        
    }
}

public class GetCategoryByIdHandler : GetBaseItemByIdHandler<Domain.Category, BaseDto>
{
    public GetCategoryByIdHandler(ICategoryRepo repo, IMapper mapper) : base(repo, mapper)
    {
    }
}
