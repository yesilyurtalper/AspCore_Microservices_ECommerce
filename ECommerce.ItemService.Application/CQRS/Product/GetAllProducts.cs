using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class GetAllProducts : GetAllBaseItems<Domain.Product,ProductDto>
{
}

public class GetAllProductsHandler : GetAllBaseItemsHandler<Domain.Product,ProductDto>
{
    public GetAllProductsHandler(IProductRepo repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
