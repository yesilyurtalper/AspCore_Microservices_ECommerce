using Microsoft.AspNetCore.Mvc;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.DTOs;
using MediatR;
using ECommerce.ItemService.Application.CQRS.Product;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [Route("itemapi/products")]
    public class ProductAPIController : BaseAPIController<Product,ProductDto>
    {
        public ProductAPIController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("brandid/{brandId}")]
        public async Task<ResponseDto<List<ProductDto>>> GetByBrandIdAsync(int brandId)
        {
            var req = new GetProductsByBrandId(brandId);
            return await _mediator.Send(req);
        }

        [HttpGet]
        [Route("categoryid/{categoryId}")]
        public async Task<ResponseDto<List<ProductDto>>> GetByCategoryIdAsync(int categoryId)
        {
            var req = new GetProductsByCategoryId(categoryId);
            return await _mediator.Send(req);
        }
    }
}
