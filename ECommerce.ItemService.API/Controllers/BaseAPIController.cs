
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.DTOs;
using MediatR;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using ECommerce.ItemService.API.Filters;
using Serilog;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [ApiController]
    public class BaseAPIController<TModel, TDto> : ControllerBase where TModel : BaseItem where TDto : BaseDto
    {
        protected IMediator _mediator;

        public BaseAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDto<List<TDto>>> GetAllAsync()
        {
            var req = new GetAllBaseItems<TModel, TDto>();
            return await _mediator.Send(req);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto<TDto>> GetByIdAsync(int id)
        {
            var req = new GetBaseItemById<TModel,TDto>(id);
            return await _mediator.Send(req);
        }

        [HttpGet]
        [Route("name/{name}")]
        public async Task<ResponseDto<TDto>> GetByNameAsync(string name)
        {
            var req = new GetBaseItemByName<TModel,TDto>(name);
            return await _mediator.Send(req);
        }

        //[ResultLogger]
        [Authorize(Policy = "ECommerceAdmin")]
        [HttpPost]
        public async Task<ResponseDto<TDto>> UpdateAsync(TDto dto)
        {
            UpdateBaseItem<TModel,TDto> command = new(dto);
            return await _mediator.Send(command);
        }

        //[ResultLogger]
        [Authorize(Policy = "ECommerceAdmin")]
        [HttpPut]
        public async Task<ResponseDto<TDto>> CreateAsync(TDto dto)
        {
            CreateBaseItem<TModel,TDto> command = new (dto);
            return await _mediator.Send(command);
        }

        //[ServiceFilter(typeof(ResultLoggerAttribute))]
        [Authorize(Policy = "ECommerceAdmin")]
        [HttpDelete]
        public async Task<ResponseDto<TDto>> DeleteAsync([FromBody]int id)
        {
            DeleteBaseItem<TModel, TDto> command = new(id);
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
