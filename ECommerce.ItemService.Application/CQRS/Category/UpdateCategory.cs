using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;
using Microsoft.Extensions.Logging;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class UpdateCategory : UpdateBaseItem<Domain.Category,BaseDto>
{
    public UpdateCategory(BaseDto dto) : base(dto)
    {
        
    }
}

public class UpdateCategoryHandler : UpdateBaseItemHandler<Domain.Category, DTOs.BaseDto>
{
    public UpdateCategoryHandler(ICategoryRepo repo, IMapper mapper,
        ILogger<UpdateCategoryHandler> logger) :
        base(repo, mapper, logger)
    {

    }
}
