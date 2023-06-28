using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class UpdateBaseItem<TModel,TDto> : IRequest<ResponseDto> 
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    public TDto _dto;

    public UpdateBaseItem(TDto dto)
    {
        _dto = dto;
    }
}