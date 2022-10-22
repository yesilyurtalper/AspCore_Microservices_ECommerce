using ECommerce.Web.Models;
using ECommerce.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ECommerce.Web.Controllers
{
    [Route("category")]
    public class CategoryController : BaseItemController<CategoryDto>
    {
        public CategoryController(IItemService apiService) : base(apiService)
        {
            base.relativeUrl = "categories";
        }
    }
}
