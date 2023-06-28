using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class UpdateBrand : UpdateBaseItem<Domain.Brand,BaseDto>
{
    public UpdateBrand(BaseDto dto) : base(dto)
    {
        
    }
}
