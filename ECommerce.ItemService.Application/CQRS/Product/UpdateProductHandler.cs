using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class UpdateProductHandler : UpdateBaseItemHandler <Domain.Product,DTOs.ProductDto>
{
    public UpdateProductHandler(IProductRepository repo, IMapper mapper) :
        base(repo,mapper)
    {
        
    }
}
