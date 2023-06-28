using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class GetProductByIdHandler : GetByIdHandler<Domain.Product, BaseDto>
{
    public GetProductByIdHandler(IProductRepository repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
