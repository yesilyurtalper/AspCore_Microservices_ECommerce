using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class DeleteBrand : DeleteBaseItem<Domain.Brand,BaseDto>
{
    public DeleteBrand(int id) : base(id)
    {
        
    }
}

public class DeleteBrandHandler : DeleteBaseItemHandler<Domain.Brand, DTOs.BaseDto>
{
    public DeleteBrandHandler(IBrandRepo repo) : base(repo)
    {

    }
}
