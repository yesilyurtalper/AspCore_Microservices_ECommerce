﻿using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class GetBrandByName : GetBaseItemByName<Domain.Brand,BaseDto>
{
    public GetBrandByName(string name) : base(name)
    {
        
    }
}

public class GetBrandByNameHandler : GetBaseItemByNameHandler<Domain.Brand, BaseDto>
{
    public GetBrandByNameHandler(IBrandRepo repo, IMapper mapper)
       : base(repo, mapper)
    {
    }
}
