using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.DTOs;
using MediatR;
using ECommerce.ItemService.Application.CQRS.Brand;
using ECommerce.ItemService.API.Constants;

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
        public async Task<ResponseDto<List<BaseDto>>> GetByCategoryIdAsync(int categoryId)
        {
            var req = new GetBrandsByCategoryId(categoryId);
            return await _mediator.Send(req);
        }

        [HttpPost]
        [Route("addcat/{brandId}")]
        [Authorize(Policy = APIConstants.ECommerceAdmin)]
        public async Task<ResponseDto<BaseDto>> AddCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            var req = new AddBrandCategories(brandId,categoryIds);
            return await _mediator.Send(req);
        }

        [HttpPost]
        [Route("remcat/{brandId}")]
        [Authorize(Policy = APIConstants.ECommerceAdmin)]
        public async Task<ResponseDto<BaseDto>> RemoveCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            var req = new RemoveBrandCategories(brandId, categoryIds);
            return await _mediator.Send(req);
        }

        [HttpPost]
        [Route("updatecat/{brandId}")]
        [Authorize(Policy = APIConstants.ECommerceAdmin)]
        public async Task<ResponseDto<BaseDto>> UpdateCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            var req = new UpdateBrandCategories(brandId, categoryIds);
            return await _mediator.Send(req);
        }
    }
}
