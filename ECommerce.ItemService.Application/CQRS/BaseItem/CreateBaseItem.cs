using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class CreateBaseItem<TModel,TDto> : IRequest<ResponseDto> 
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    public TDto _dto;

    public CreateBaseItem(TDto dto)
    {
        _dto = dto;
    }
}