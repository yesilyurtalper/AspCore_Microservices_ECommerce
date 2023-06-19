using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.Dtos;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [Route("itemapi/brands")]
    public class BrandAPIController : BaseAPIController<Brand, BaseDto>
    {
        private IBrandRepository _brandRepo;

        public BrandAPIController(IBrandRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _brandRepo = repo;
        }

        [HttpGet]
        [Route("categoryid/{categoryId}")]
        public async Task<ResponseDto> GetByCategoryIdAsync(int categoryId)
        {
            try
            {
                var models = await _brandRepo.GetAllBrandsByCategoryIdAsync(categoryId);
                var dtos = _mapper.Map<List<BaseDto>>(models);
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

        [HttpPost]
        [Route("addcat/{brandId}")]
        [Authorize(Policy = "ECommerceAdmin")]
        public async Task<ResponseDto> AddCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            try
            {
                await _brandRepo.AddCategoriesAsync(brandId, categoryIds);
                await _repo.SaveChangesAsync();
                _response.Result = _mapper.Map<BaseDto>(await _brandRepo.GetByIdAsync(brandId));
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [Route("remcat/{brandId}")]
        [Authorize(Policy = "ECommerceAdmin")]
        public async Task<ResponseDto> RemoveCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            try
            {
                await _brandRepo.RemoveCategoriesAsync(brandId, categoryIds);
                await _repo.SaveChangesAsync();
                _response.Result = _mapper.Map<BaseDto>(await _brandRepo.GetByIdAsync(brandId));
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [Route("updatecat/{brandId}")]
        [Authorize(Policy = "ECommerceAdmin")]
        public async Task<ResponseDto> UpdateCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            try
            {
                await _brandRepo.UpdateCategoriesAsync(brandId, categoryIds);
                await _repo.SaveChangesAsync();
                _response.Result = _mapper.Map<BaseDto>(await _brandRepo.GetByIdAsync(brandId));
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
