using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class CreateBaseItem<TDto> : IRequest<ResponseDto> where TDto : BaseDto
{
    public TDto _dto;

    public CreateBaseItem(TDto dto)
    {
        _dto = dto;
    }
}