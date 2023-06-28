﻿using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class CreateProduct : CreateBaseItem<Domain.Product,ProductDto>
{
    public CreateProduct(ProductDto dto) : base(dto)
    {
        
    }
}
