using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class GetProductByName : GetBaseItemByName<Domain.Product,BaseDto>
{
    public GetProductByName(string name) : base(name)
    {
        
    }
}

public class GetProductByNameHandler : GetBaseItemByNameHandler<Domain.Product, BaseDto>
{
    public GetProductByNameHandler(IProductRepo repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
