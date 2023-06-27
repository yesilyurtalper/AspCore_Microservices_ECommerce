using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class CreateBrandHandler : CreateBaseItemHandler <Domain.Brand, DTOs.BaseDto>
{
    public CreateBrandHandler(IBrandRepository repo, IMapper mapper) :
        base(repo,mapper)
    {
        
    }
}
