using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class UpdateProduct : UpdateBaseItem<Domain.Product,ProductDto>
{
    public UpdateProduct(ProductDto dto) : base(dto)
    {
        
    }
}
