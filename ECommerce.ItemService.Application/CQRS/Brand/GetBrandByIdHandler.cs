using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class GetBrandByIdHandler : GetByIdHandler<Domain.Brand, BaseDto>
{
    public GetBrandByIdHandler(IBrandRepository repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
