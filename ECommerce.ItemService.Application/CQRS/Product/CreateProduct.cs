﻿using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;
using Microsoft.Extensions.Logging;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class CreateProduct : CreateBaseItem<Domain.Product,ProductDto>
{
    public CreateProduct(ProductDto dto) : base(dto)
    {
        
    }
}

public class CreateProductHandler : CreateBaseItemHandler<Domain.Product, DTOs.ProductDto>
{
    public CreateProductHandler(IProductRepo repo, IMapper mapper,
        ILogger<CreateProductHandler> logger) : base(repo, mapper, logger)
    {

    }
}
