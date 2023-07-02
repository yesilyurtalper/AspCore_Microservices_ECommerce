using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class CreateCategory : CreateBaseItem<Domain.Category,BaseDto>
{
    public CreateCategory(BaseDto dto) : base(dto)
    {

    }
}

public class CreateCategoryHandler : CreateBaseItemHandler<Domain.Category, DTOs.BaseDto>
{
    public CreateCategoryHandler(ICategoryRepo repo, IMapper mapper) :
        base(repo, mapper)
    {

    }
}
