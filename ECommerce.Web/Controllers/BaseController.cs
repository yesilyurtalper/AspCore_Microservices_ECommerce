using ECommerce.Web.Models;
using ECommerce.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.Web.Controllers
{
    public class BaseController<TDto> : Controller where TDto : BaseDto
    {
        protected readonly IAPIService _apiService;
        protected string url = "";

        public BaseController(IAPIService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            List<TDto> items = new();
            var response = await _apiService.GetAllItemsAsync<ResponseDto>(url);
            if(response != null && response.IsSuccess)
            {
                items = JsonConvert.DeserializeObject<List<TDto>>(Convert.ToString(response.Result));
            }
            return View(items);
        }

        public async Task<List<TDto>> GetAll()
        {
            List<TDto> items = new();
            var response = await _apiService.GetAllItemsAsync<ResponseDto>(url);
            if (response != null && response.IsSuccess)
                items = JsonConvert.DeserializeObject<List<TDto>>(Convert.ToString(response.Result));
            return items;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _apiService.GetItemByIdAsync<ResponseDto>(url, id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<TDto>(Convert.ToString(response.Result));
                return View(model);
            }
                
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TDto dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _apiService.UpdateItemAsync<ResponseDto, TDto>(url, dto);
                if (response != null && response.IsSuccess)
                    return RedirectToAction("Details", new { id = dto.Id });
                else
                {
                    foreach (var error in response.ErrorMessages)
                        ModelState.AddModelError("error", error);
                    return View(dto);
                }
            }

            return View(dto);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiService.GetItemByIdAsync<ResponseDto>(url, id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<TDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }   

        public virtual async Task<IActionResult> Create()
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TDto dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _apiService.CreateItemAsync<ResponseDto, TDto>(url, dto);
                if (response != null && response.IsSuccess)
                    return RedirectToAction("Details", new { id = JsonConvert.DeserializeObject<TDto>(Convert.ToString(response.Result)).Id });
                else
                {
                    foreach (var error in response.ErrorMessages)
                        ModelState.AddModelError("error", error);
                    return View(dto);
                }
            }

            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.GetItemByIdAsync<ResponseDto>(url, id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<TDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TDto dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _apiService.DeleteItemAsync<ResponseDto>(url, dto.Id);
                if (response != null && response.IsSuccess)
                    return RedirectToAction("Index");
            }
            return View(dto);
        }
    }
}
