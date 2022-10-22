using Microsoft.AspNetCore.Mvc;
using ECommerce.APIs.ItemAPI.Services;
using ECommerce.APIs.ItemAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [Route("itemapi/brands")]
    public class BrandAPIController : BaseAPIController<Brand, BrandDto>
    {
        private IBrandRepository _brandRepo;

        public BrandAPIController(IBrandRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _brandRepo = repo;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("categoryid/{categoryId}")]
        public async Task<ResponseDto> GetByCategoryIdAsync(int categoryId)
        {
            try
            {
                var models = await _brandRepo.GetAllBrandsByCategoryIdAsync(categoryId);
                var dtos = _mapper.Map<List<BrandDto>>(models);
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
        public async Task<ResponseDto> AddCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            try
            {
                await _brandRepo.AddCategorieAsync(brandId, categoryIds);
                await _repo.SaveChangesAsync();
                _response.Result = _mapper.Map<BrandDto>(await _brandRepo.GetByIdAsync(brandId));
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
        public async Task<ResponseDto> RemoveCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            try
            {
                await _brandRepo.RemoveCategoriesAsync(brandId, categoryIds);
                await _repo.SaveChangesAsync();
                _response.Result = _mapper.Map<BrandDto>(await _brandRepo.GetByIdAsync(brandId));
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
        public async Task<ResponseDto> UpdateCategoryAsync(int brandId, [FromBody]List<int> categoryIds)
        {
            try
            {
                await _brandRepo.UpdateCategoriesAsync(brandId, categoryIds);
                await _repo.SaveChangesAsync();
                _response.Result = _mapper.Map<BrandDto>(await _brandRepo.GetByIdAsync(brandId));
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
