using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class GetById<TModel,TDto> : IRequest<ResponseDto>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    public int Id { get; set; }
    public GetById(int id)
    {
        Id = id;
    }
}
