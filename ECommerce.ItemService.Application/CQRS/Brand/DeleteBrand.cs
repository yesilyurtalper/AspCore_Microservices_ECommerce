using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class DeleteBrand : DeleteBaseItem<Domain.Brand,BaseDto>
{
    public DeleteBrand(int id) : base(id)
    {
        
    }
}
