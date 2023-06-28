using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class DeleteProduct : DeleteBaseItem<Domain.Product,BaseDto>
{
    public DeleteProduct(int id) : base(id)
    {
        
    }
}
