using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class UpdateBrandHandler : UpdateBaseItemHandler <Domain.Brand, DTOs.BaseDto>
{
    public UpdateBrandHandler(IBrandRepository repo, IMapper mapper) :
        base(repo,mapper)
    {
        
    }
}
