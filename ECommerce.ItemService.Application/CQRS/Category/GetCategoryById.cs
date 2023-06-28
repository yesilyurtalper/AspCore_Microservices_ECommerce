using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class GetCategoryById : GetAll<Domain.Category,BaseDto>
{
}
