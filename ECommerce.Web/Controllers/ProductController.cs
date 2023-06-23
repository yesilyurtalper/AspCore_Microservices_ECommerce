using ECommer.ItemUI.Models;
using ECommer.ItemUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ECommer.ItemUI.Controllers
{
    [Route("product")]
    public class ProductController : BaseItemController<ProductDto>
    {
        public ProductController(IItemService itemService) : base(itemService)
        {
            base.relativeUrl = "products";
        }
    }
}
