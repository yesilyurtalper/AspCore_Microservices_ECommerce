using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;
using Microsoft.Extensions.Logging;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class UpdateProduct : UpdateBaseItem<Domain.Product,ProductDto>
{
    public UpdateProduct(ProductDto dto) : base(dto)
    {
        
    }
}

public class UpdateProductHandler : UpdateBaseItemHandler<Domain.Product, DTOs.ProductDto>
{
    public UpdateProductHandler(IProductRepo repo, IMapper mapper, ILogger<UpdateProductHandler> logger) :
        base(repo, mapper, logger)
    {

    }
}
