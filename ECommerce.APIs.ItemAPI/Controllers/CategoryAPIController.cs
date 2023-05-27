using Microsoft.AspNetCore.Mvc;
using ECommerce.APIs.ItemAPI.Services;
using ECommerce.APIs.ItemAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [Route("itemapi/categories")]
    public class CategoryAPIController : BaseAPIController<Category, CategoryDto>
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
                var dtos = _mapper.Map<List<CategoryDto>>(entities);
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
                var dtos = _mapper.Map<List<CategoryDto>>(entities);
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
