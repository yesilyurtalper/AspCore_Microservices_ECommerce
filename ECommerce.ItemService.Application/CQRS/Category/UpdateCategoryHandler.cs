using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class UpdateCategoryHandler : UpdateBaseItemHandler <Domain.Category,DTOs.BaseDto>
{
    public UpdateCategoryHandler(ICategoryRepository repo, IMapper mapper) :
        base(repo,mapper)
    {
        
    }
}
