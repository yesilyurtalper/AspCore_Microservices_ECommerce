﻿using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class DeleteBaseItem<TModel,TDto> : IRequest<ResponseDto>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    public int Id;

    public DeleteBaseItem(int id)
    {
        Id = id;
    }
}