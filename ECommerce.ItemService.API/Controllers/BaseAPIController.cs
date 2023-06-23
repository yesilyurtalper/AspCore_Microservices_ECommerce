using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.Dtos;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    public class BaseAPIController<TModel, TDto> : ControllerBase where TModel : BaseItem where TDto : BaseDto
    {
        protected ResponseDto _response;
        protected readonly IRepository<TModel> _repo;
        protected readonly IMapper _mapper;

        public BaseAPIController(IRepository<TModel> repo, IMapper mapper)
        {
            _repo = repo;
            _response = new ResponseDto();
            _mapper = mapper;
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
        public async Task<ResponseDto> UpdateAsync([FromBody] TDto dto)
        {
            if (dto == null || ModelState.IsValid == false)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToList<string>();
                return _response;
            }

            var model = await _repo.GetByIdAsync(dto.Id);
            if (model == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "not found" };
                return _response;
            }

            _mapper.Map(dto, model);
            await _repo.UpdateAsync(model);
            await _repo.SaveChangesAsync();
            _response.Result = _mapper.Map<TDto>(model);
            _response.IsSuccess = true;

            return _response;
        }

        [Authorize(Policy = "ECommerceAdmin")]
        [HttpPut]
        public async Task<ResponseDto> CreateAsync([FromBody] TDto dto)
        {
            if (dto == null || ModelState.IsValid == false)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToList<string>();
                return _response;
            }

            var model = _mapper.Map<TModel>(dto);
            await _repo.CreateAsync(model);
            await _repo.SaveChangesAsync();
            _response.Result = _mapper.Map<TDto>(model);
            _response.IsSuccess = true;

            return _response;
        }

        [Authorize(Policy = "ECommerceAdmin")]
        [HttpDelete]
        public async Task<ResponseDto> DeleteAsync([FromBody]int id)
        {
            var model = await _repo.GetByIdAsync(id);
            if (model == null)
            {
                _response.ErrorMessages = new List<string> { "not found to delete" };
                _response.IsSuccess = false;
            }
            else
            {
                await _repo.DeleteAsync(model);
                await _repo.SaveChangesAsync();
                _response.IsSuccess = true;
            }

            return _response;
        }
    }
}
