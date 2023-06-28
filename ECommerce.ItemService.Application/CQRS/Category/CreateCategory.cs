﻿using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class CreateCategory : CreateBaseItem<Domain.Category,BaseDto>
{
    public CreateCategory(BaseDto dto) : base(dto)
    {

    }
}
