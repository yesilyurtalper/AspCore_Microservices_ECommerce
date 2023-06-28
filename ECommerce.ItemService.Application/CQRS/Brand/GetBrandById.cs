using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class GetBrandById : GetAll<Domain.Brand,BaseDto>
{
}
