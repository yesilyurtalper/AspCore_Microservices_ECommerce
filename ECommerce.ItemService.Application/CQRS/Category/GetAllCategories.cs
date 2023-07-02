using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class GetAllCategories : GetAllBaseItems<Domain.Category,BaseDto>
{
}

public class GetAllCategoriesHandler : GetAllBaseItemsHandler<Domain.Category, BaseDto>
{
    public GetAllCategoriesHandler(ICategoryRepo repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
