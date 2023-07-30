using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;
using Microsoft.Extensions.Logging;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class DeleteCategory : DeleteBaseItem<Domain.Category,BaseDto>
{
    public DeleteCategory(int id) : base(id)
    {
        
    }
}

public class DeleteCategoryHandler : DeleteBaseItemHandler<Domain.Category, DTOs.BaseDto>
{
    public DeleteCategoryHandler(ICategoryRepo repo, ILogger<DeleteCategoryHandler> logger, 
        IMapper mapper) : base(repo, logger, mapper)
    {

    }
}
