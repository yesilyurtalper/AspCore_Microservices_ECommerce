using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class DeleteBaseItem : IRequest<ResponseDto>
{
    public int Id;

    public DeleteBaseItem(int id)
    {
        Id = id;
    }
}