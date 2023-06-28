using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class DeleteCategory : DeleteBaseItem<Domain.Category,BaseDto>
{
    public DeleteCategory(int id) : base(id)
    {
        
    }
}
