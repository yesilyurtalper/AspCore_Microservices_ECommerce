using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class GetAllBrandsHandler : GetAllHandler<Domain.Brand, BaseDto>
{
    public GetAllBrandsHandler(IBrandRepository repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
