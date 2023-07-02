
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.DTOs;
using MediatR;
using ECommerce.ItemService.Application.CQRS.BaseItem;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [ApiController]
    public class BaseAPIController<TModel, TDto> : ControllerBase where TModel : BaseItem where TDto : BaseDto
    {
        protected ResponseDto _response;
        protected IMediator _mediator;

        public BaseAPIController(IMediator mediator)
        {
            _response = new ResponseDto();
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDto> GetAllAsync()
        {
            var req = new GetAllBaseItems<TModel, TDto>();
            return await _mediator.Send(req);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> GetByIdAsync(int id)
        {
            var req = new GetBaseItemById<TModel,TDto>(id);
            return await _mediator.Send(req);
        }

        [HttpGet]
        [Route("name/{name}")]
        public async Task<ResponseDto> GetByNameAsync(string name)
        {
            var req = new GetBaseItemByName<TModel,TDto>(name);
            return await _mediator.Send(req);
        }

        [Authorize(Policy = "ECommerceAdmin")]
        [HttpPost]
        public async Task<ResponseDto> UpdateAsync(TDto dto)
        {
            UpdateBaseItem<TModel,TDto> command = new(dto);
            return await _mediator.Send(command);
        }

        [Authorize(Policy = "ECommerceAdmin")]
        [HttpPut]
        public async Task<ResponseDto> CreateAsync(TDto dto)
        {
            CreateBaseItem<TModel,TDto> command = new (dto);
            return await _mediator.Send(command);
        }

        [Authorize(Policy = "ECommerceAdmin")]
        [HttpDelete]
        public async Task<ResponseDto> DeleteAsync([FromBody]int id)
        {
            DeleteBaseItem<TModel, TDto> command = new(id);
            return await _mediator.Send(command);
        }
    }
}
