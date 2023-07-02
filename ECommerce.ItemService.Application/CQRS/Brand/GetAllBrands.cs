using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class GetAllBrands : GetAllBaseItems<Domain.Brand,BaseDto>
{
}

public class GetAllBrandsHandler : GetAllBaseItemsHandler<Domain.Brand, BaseDto>
{
    public GetAllBrandsHandler(IBrandRepo repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
