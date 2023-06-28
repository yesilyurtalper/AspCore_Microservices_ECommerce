using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;
using ECommerce.ItemService.Application.CQRS.BaseItem;
using System.Xml.Linq;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [ApiController]
    public class BaseAPIController<TModel, TDto> : ControllerBase where TModel : BaseItem where TDto : BaseDto
    {
        protected ResponseDto _response;
        protected readonly IRepository<TModel> _repo;
        protected readonly IMapper _mapper;
        private IMediator _mediator;

        public BaseAPIController(IRepository<TModel> repo, IMapper mapper, IMediator mediator)
        {
            _repo = repo;
            _response = new ResponseDto();
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDto> GetAllAsync()
        {
            var req = new GetAll<TModel, TDto>();
            return await _mediator.Send(req);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> GetByIdAsync(int id)
        {
            var req = new GetById<TModel,TDto>(id);
            return await _mediator.Send(req);
        }

        [HttpGet]
        [Route("name/{name}")]
        public async Task<ResponseDto> GetByNameAsync(string name)
        {
            var req = new GetByName<TModel,TDto>(name);
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
