using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class DeleteBrandHandler : DeleteBaseItemHandler <Domain.Brand,DTOs.BaseDto>
{
    public DeleteBrandHandler(IBrandRepository repo, IMapper mapper) :
        base(repo,mapper)
    {
        
    }
}
