using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;
using Microsoft.Extensions.Logging;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class DeleteProduct : DeleteBaseItem<Domain.Product,BaseDto>
{
    public DeleteProduct(int id) : base(id)
    {
        
    }
}

public class DeleteProductHandler : DeleteBaseItemHandler<Domain.Product, DTOs.ProductDto>
{
    public DeleteProductHandler(IProductRepo repo, ILogger<DeleteProductHandler> logger,
        IMapper mapper) : base(repo, logger, mapper)
    {

    }
}
