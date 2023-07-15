using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;
using Microsoft.Extensions.Logging;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class GetProductById : GetBaseItemById<Domain.Product,ProductDto>
{
    public GetProductById(int id) : base(id)
    {
        
    }
}

public class GetProductByIdHandler : GetBaseItemByIdHandler<Domain.Product, ProductDto>
{
    public GetProductByIdHandler(IProductRepo repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
