using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class DeleteProduct : DeleteBaseItem<Domain.Product,BaseDto>
{
    public DeleteProduct(int id) : base(id)
    {
        
    }
}

public class DeleteProductHandler : DeleteBaseItemHandler<Domain.Product, DTOs.ProductDto>
{
    public DeleteProductHandler(IProductRepo repo) : base(repo)
    {

    }
}
