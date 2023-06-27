using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.APIs.ItemAPI.Controllers
{
    [Route("itemapi/products")]
    public class ProductAPIController : BaseAPIController<Product,ProductDto>
    {
        private readonly IProductRepository _productRepo;
        public ProductAPIController(IProductRepository repo, IMapper mapper, IMediator mediator) 
            : base(repo,mapper, mediator)
        {
            _productRepo = repo;
        }

        [HttpGet]
        [Route("brandid/{brandId}")]
        public async Task<ResponseDto> GetByBrandIdAsync(int brandId)
        {
            var models = await _productRepo.GetAllProductsByBrandIdAsync(brandId);
            var dtos = _mapper.Map<List<ProductDto>>(models);
            _response.Result = dtos;
            _response.IsSuccess = true;

            return _response;
        }

        [HttpGet]
        [Route("categoryid/{categoryId}")]
        public async Task<ResponseDto> GetByCategoryIdAsync(int categoryId)
        {
            var models = await _productRepo.GetAllProductsByCategoryIdAsync(categoryId);
            var dtos = _mapper.Map<List<ProductDto>>(models);
            _response.Result = dtos;
            _response.IsSuccess = true;

            return _response;
        }
    }
}
