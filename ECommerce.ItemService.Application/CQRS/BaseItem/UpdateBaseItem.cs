using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class UpdateBaseItem<TDto> : IRequest<ResponseDto> where TDto : BaseDto
{
    public TDto _dto;

    public UpdateBaseItem(TDto dto)
    {
        _dto = dto;
    }
}