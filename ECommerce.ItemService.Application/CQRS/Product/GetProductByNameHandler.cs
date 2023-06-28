using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class GetProductByNameHandler : GetByNameHandler<Domain.Product, BaseDto>
{
    public GetProductByNameHandler(IProductRepository repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
