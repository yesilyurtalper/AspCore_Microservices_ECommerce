using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class DeleteCategoryHandler : DeleteBaseItemHandler <Domain.Category,DTOs.BaseDto>
{
    public DeleteCategoryHandler(ICategoryRepository repo, IMapper mapper) :
        base(repo,mapper)
    {
        
    }
}
