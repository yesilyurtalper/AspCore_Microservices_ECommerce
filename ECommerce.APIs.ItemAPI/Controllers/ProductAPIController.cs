using Microsoft.AspNetCore.Mvc;
using ECommerce.APIs.ItemAPI.Services;
using ECommerce.APIs.ItemAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ECommerce.ItemService.Domain;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [Route("itemapi/products")]
    public class ProductAPIController : BaseAPIController<Product,ProductDto>
    {
        private IProductRepository _productRepo;
        public ProductAPIController(IProductRepository repo, IMapper mapper) : base(repo,mapper)
        {
            _productRepo = repo;
        }

        [HttpGet]
        [Route("brandid/{brandId}")]
        public async Task<ResponseDto> GetByBrandIdAsync(int brandId)
        {
            try
            {
                var models = await _productRepo.GetAllProductsByBrandIdAsync(brandId);
                var dtos = _mapper.Map<List<ProductDto>>(models);
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
        [Route("categoryid/{categoryId}")]
        public async Task<ResponseDto> GetByCategoryIdAsync(int categoryId)
        {
            try
            {
                var models = await _productRepo.GetAllProductsByCategoryIdAsync(categoryId);
                var dtos = _mapper.Map<List<ProductDto>>(models);
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
