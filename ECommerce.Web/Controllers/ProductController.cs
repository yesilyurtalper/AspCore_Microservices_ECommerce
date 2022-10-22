using ECommerce.Web.Models;
using ECommerce.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ECommerce.Web.Controllers
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
