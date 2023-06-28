using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class DeleteProductHandler : DeleteBaseItemHandler <Domain.Product, DTOs.ProductDto>
{
    public DeleteProductHandler(IProductRepository repo, IMapper mapper) :
        base(repo,mapper)
    {
        
    }
}
