using ECommer.ItemUI.Models;
using ECommer.ItemUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ECommer.ItemUI.Controllers
{
    [Route("category")]
    public class CategoryController : BaseItemController<BaseDto>
    {
        public CategoryController(IItemService apiService) : base(apiService)
        {
            base.relativeUrl = "categories";
        }
    }
}
