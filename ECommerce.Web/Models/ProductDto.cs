using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class ProductDto : ProductBaseDto
    {
        public BaseDto CategoryBaseDto { get; set; }
        public BaseDto BrandBaseDto { get; set; }
    }
}
