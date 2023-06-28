using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class GetByName<TModel,TDto> : IRequest<ResponseDto>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    public string Name { get; set; }
    public GetByName(string name)
    {
        Name = name;
    }
}
