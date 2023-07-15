using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;
using Microsoft.Extensions.Logging;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class UpdateBrand : UpdateBaseItem<Domain.Brand,BaseDto>
{
    public UpdateBrand(BaseDto dto) : base(dto)
    {
        
    }
}

public class UpdateBrandHandler : UpdateBaseItemHandler<Domain.Brand, DTOs.BaseDto>
{
    public UpdateBrandHandler(IBrandRepo repo, IMapper mapper, ILogger<UpdateBrandHandler> logger) :
        base(repo, mapper, logger)
    {

    }
}
