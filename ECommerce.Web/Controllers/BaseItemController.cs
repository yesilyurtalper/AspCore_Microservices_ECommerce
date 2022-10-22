using ECommerce.Web.Models;
using ECommerce.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.Web.Controllers
{
    public class BaseItemController<TDto> : Controller where TDto : BaseDto
    {
        protected readonly IItemService _itemService;
        protected string relativeUrl = "";

        public BaseItemController(IItemService apiService)
        {
            _itemService = apiService;
        }

        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var items = await GetAllAsync();
            return View(items);
        }

        [Route("getall")]
        public async Task<List<TDto>> GetAllAsync()
        {          
            List<TDto> items = new();

            var response = await _itemService.GetAsync<ResponseDto>(relativeUrl, await GetAccessTokenAsync());
            
            if (response.IsSuccess)
                items = JsonConvert.DeserializeObject<List<TDto>>(Convert.ToString(response.Result));
            return items;
        }

        [Route("getallbyextid/{type}/{id}")]
        public async Task<List<TDto>> GetAllByExtIdAsync(string type, int id)
        {
            List<TDto> items = new();
            var response = await _itemService.GetAsync<ResponseDto>(relativeUrl+"/"+type+"/"+id, await GetAccessTokenAsync());
            
            if (response.IsSuccess)
                items = JsonConvert.DeserializeObject<List<TDto>>(Convert.ToString(response.Result));
            return items;
        }

        [Route("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _itemService.GetAsync<ResponseDto>(relativeUrl + "/" + id, await GetAccessTokenAsync());

            if (response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<TDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [Authorize(Roles ="Admin")]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _itemService.GetAsync<ResponseDto>(relativeUrl+"/"+id, await GetAccessTokenAsync());

            if (response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<TDto>(Convert.ToString(response.Result));
                return View(model);
            }
                
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("edit")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> EditPost(TDto dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _itemService.UpdateItemAsync<ResponseDto, TDto>(relativeUrl, dto, await GetAccessTokenAsync());
                
                if (response.IsSuccess)
                    return RedirectToAction(nameof(Details), new { id = dto.Id });
                else
                {
                    foreach (var error in response.ErrorMessages)
                        ModelState.AddModelError("error", error);
                    return View(nameof(Edit),dto);
                }
            }

            return View(nameof(Edit), dto);
        }

        [Authorize(Roles = "Admin")]
        [Route("create")]
        public async Task<IActionResult> Create()
        {           
            return View();
        }

        [Authorize(Roles = "Admin")]
        [Route("create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> CreatePost(TDto dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _itemService.CreateItemAsync<ResponseDto, TDto>(relativeUrl, dto, await GetAccessTokenAsync());
                
                if (response.IsSuccess)
                    return RedirectToAction(nameof(Details), 
                        new { id = JsonConvert.DeserializeObject<TDto>(Convert.ToString(response.Result)).Id });
                else
                {
                    foreach (var error in response.ErrorMessages)
                        ModelState.AddModelError("error", error);
                    return View(nameof(Create),dto);
                }
            }

            return View(nameof(Create),dto);
        }

        [Authorize(Roles = "Admin")]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _itemService.GetAsync<ResponseDto>(relativeUrl+"/"+id, await GetAccessTokenAsync());

            if (response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<TDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [Route("delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(TDto dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _itemService.DeleteItemAsync<ResponseDto>(relativeUrl, dto.Id, await GetAccessTokenAsync());
                
                if (response.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                {
                    foreach (var error in response.ErrorMessages)
                        ModelState.AddModelError("error", error);
                    return View(nameof(Delete), dto);
                }
            }

            return View(nameof(Delete),dto);
        }

        protected async Task<string> GetAccessTokenAsync()
        {
            return await HttpContext.GetTokenAsync("access_token");
        }
    }
}
