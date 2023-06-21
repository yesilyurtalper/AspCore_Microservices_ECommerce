using ECommerce.Web.Models;
using ECommerce.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ECommerce.Web.Controllers
{
    [Route("brand")]
    public class BrandController : BaseItemController<BrandDto>
    {

        public BrandController(IItemService itemService) : base(itemService)
        {
            base.relativeUrl = "brands";
        }

        [Authorize(Policy = "ECommerceAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public override async Task<IActionResult> CreatePost(BrandDto dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _itemService.CreateItemAsync<ResponseDto, BrandDto>(relativeUrl, dto, await GetAccessTokenAsync());
                if (response != null && response.IsSuccess)
                {
                    int newId = JsonConvert.DeserializeObject<BrandDto>(Convert.ToString(response.Result)).Id;
                    var result2 = _itemService.AddCategoryToBrandAsync<ResponseDto, BrandDto>
                        (relativeUrl+"/addcat/"+newId, dto.CategoryIdAdd, await GetAccessTokenAsync());

                    return RedirectToAction(nameof(Details), new {id = newId });
                }
                else
                {
                    foreach (var error in response.ErrorMessages)
                        ModelState.AddModelError("error", error);
                    return View(nameof(Create),dto);
                }
            }

            return View(nameof(Create), dto);
        }

        [Authorize(Policy = "ECommerceAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit")]
        public override async Task<IActionResult> EditPost(BrandDto dto)
        {
            if (ModelState.IsValid)
            {
                var resp1 = await _itemService.UpdateItemAsync<ResponseDto, BrandDto>(relativeUrl, dto, await GetAccessTokenAsync());
                
                ResponseDto resp2 = new();
                resp2.IsSuccess = true;
                if (dto.CategoryIdAdd != null && dto.CategoryIdAdd.Count != 0)
                    resp2 = await _itemService.AddCategoryToBrandAsync<ResponseDto, BrandDto>
                        (relativeUrl + "/addcat/" + dto.Id, dto.CategoryIdAdd, await GetAccessTokenAsync());

                ResponseDto resp3 = new();
                resp3.IsSuccess = true;
                if (dto.CategoryIdRemove != null && dto.CategoryIdRemove.Count != 0)
                    resp3 = await _itemService.RemoveCategoryFromBrandAsync<ResponseDto, BrandDto>
                        (relativeUrl + "/remcat/" + dto.Id, dto.CategoryIdRemove, await GetAccessTokenAsync());

                bool err = false;
                if(resp1 is null || resp1.IsSuccess == false)
                {
                    err = true;
                    foreach (var error in resp1.ErrorMessages)
                        ModelState.AddModelError("error", error);
                }

                if (resp2 is null || resp2.IsSuccess == false)
                {
                    err = true;
                    foreach (var error in resp2.ErrorMessages)
                        ModelState.AddModelError("error", error);
                }

                if (resp3 is null || resp3.IsSuccess == false)
                {
                    err = true;
                    foreach (var error in resp3.ErrorMessages)
                        ModelState.AddModelError("error", error);
                }

                if (err == false)
                    return RedirectToAction(nameof(Details), new { id = dto.Id });
                else
                    return View(nameof(Edit), dto);
            }

            return View(nameof(Edit), dto);
        }
    }
}
