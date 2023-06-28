using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class GetAllProductsHandler : GetAllHandler<Domain.Product, BaseDto>
{
    public GetAllProductsHandler(IProductRepository repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
