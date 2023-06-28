using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class GetAllCategoriesHandler : GetAllHandler<Domain.Category, BaseDto>
{
    public GetAllCategoriesHandler(ICategoryRepository repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
