using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class CreateBrand : CreateBaseItem<Domain.Brand,BaseDto>
{
    public CreateBrand(BaseDto dto) : base(dto)
    {
        
    }
}

public class CreateBrandHandler : CreateBaseItemHandler<Domain.Brand, DTOs.BaseDto>
{
    public CreateBrandHandler(IBrandRepo repo, IMapper mapper) :
        base(repo, mapper)
    {

    }
}
