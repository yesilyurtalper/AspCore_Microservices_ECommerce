using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.DTOs;
using MediatR;
using ECommerce.ItemService.Application.CQRS.Brand;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [Route("itemapi/brands")]
    public class BrandAPIController : BaseAPIController<Brand, BaseDto>
    {
        public BrandAPIController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("categoryid/{categoryId}")]
        public async Task<ResponseDto> GetByCategoryIdAsync(int categoryId)
        {
            var req = new GetBrandsByCategoryId(categoryId);
            return await _mediator.Send(req);
        }

        [HttpPost]
        [Route("addcat/{brandId}")]
        [Authorize(Policy = "ECommerceAdmin")]
        public async Task<ResponseDto> AddCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            var req = new AddBrandCategories(brandId,categoryIds);
            return await _mediator.Send(req);
        }

        [HttpPost]
        [Route("remcat/{brandId}")]
        [Authorize(Policy = "ECommerceAdmin")]
        public async Task<ResponseDto> RemoveCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            var req = new RemoveBrandCategories(brandId, categoryIds);
            return await _mediator.Send(req);
        }

        [HttpPost]
        [Route("updatecat/{brandId}")]
        [Authorize(Policy = "ECommerceAdmin")]
        public async Task<ResponseDto> UpdateCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            var req = new UpdateBrandCategories(brandId, categoryIds);
            return await _mediator.Send(req);
        }
    }
}
