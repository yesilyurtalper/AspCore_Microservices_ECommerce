using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class CreateProductCommandHandler : CreateBaseItemHandler <Domain.Product, DTOs.ProductDto>
{
    public CreateProductCommandHandler(IProductRepository repo, IMapper mapper) :
        base(repo,mapper)
    {
        
    }
}
