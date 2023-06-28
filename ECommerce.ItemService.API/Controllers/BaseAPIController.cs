using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;
using ECommerce.ItemService.Application.CQRS.BaseItem;

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
            var models = await _repo.GetAllAsync();
            var dtos = _mapper.Map<List<TDto>>(models);
            _response.Result = dtos;
            _response.IsSuccess = true;

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> GetByIdAsync(int id)
        {
            var model = await _repo.GetByIdAsync(id);
            if (model == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "not found" };
            }
            else
            {
                _response.IsSuccess = true;
                var dto = _mapper.Map<TDto>(model);
                _response.Result = dto;
            }

            return _response;
        }

        [HttpGet]
        [Route("name/{name}")]
        public async Task<ResponseDto> GetByNameAsync(string name)
        {
            var model = await _repo.GetByNameAsync(name);
            if (model == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "not found" };
            }
            else
            {
                _response.IsSuccess = true;
                var dto = _mapper.Map<TDto>(model);
                _response.Result = dto;
            }

            return _response;
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
