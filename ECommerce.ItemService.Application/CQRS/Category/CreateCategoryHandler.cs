using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class CreateCategoryHandler : CreateBaseItemHandler<Domain.Category, DTOs.BaseDto>
{
    public CreateCategoryHandler(ICategoryRepository repo, IMapper mapper) :
        base(repo, mapper)
    {

    }
}
