using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.Dtos;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [Route("itemapi/categories")]
    public class CategoryAPIController : BaseAPIController<Category, BaseDto>
    {
        private ICategoryRepository _categoryRepo;

        public CategoryAPIController(ICategoryRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _categoryRepo = repo;
        }

        [HttpGet]
        [Route("brandid/{brandId}")]
        public async Task<ResponseDto> GetByBrandIdAsync(int brandId)
        {
            try
            {
                var entities = await _categoryRepo.GetAllCategoriesByBrandIdAsync(brandId);
                var dtos = _mapper.Map<List<BaseDto>>(entities);
                _response.Result = dtos;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("outofbrandid/{brandId}")]
        public async Task<ResponseDto> GetOutOfBrandIdAsync(int brandId)
        {
            try
            {
                var entities = await _categoryRepo.GetAllCategoriesOutOfBrandIdAsync(brandId);
                var dtos = _mapper.Map<List<BaseDto>>(entities);
                _response.Result = dtos;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }
    }
}
