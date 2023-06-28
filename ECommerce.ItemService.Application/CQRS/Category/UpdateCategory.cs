using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class UpdateCategory : UpdateBaseItem<Domain.Category,BaseDto>
{
    public UpdateCategory(BaseDto dto) : base(dto)
    {
        
    }
}
