using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;
using ECommerce.ItemService.Application.CQRS.Brand;
using ECommerce.ItemService.Application.CQRS.Category;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [Route("itemapi/categories")]
    public class CategoryAPIController : BaseAPIController<Category, BaseDto>
    {

        public CategoryAPIController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("brandid/{brandId}")]
        public async Task<ResponseDto<List<BaseDto>>> GetByBrandIdAsync(int brandId)
        {
            var req = new GetCategoriesByBrandId(brandId);
            return await _mediator.Send(req);
        }

        [HttpGet]
        [Route("outofbrandid/{brandId}")]
        public async Task<ResponseDto<List<BaseDto>>> GetOutOfBrandIdAsync(int brandId)
        {
            var req = new GetCategoriesOutOfByBrandId(brandId);
            return await _mediator.Send(req);
        }
    }
}
