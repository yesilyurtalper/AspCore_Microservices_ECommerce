using System.ComponentModel.DataAnnotations;

namespace ECommerce.APIs.ItemAPI.Models
{
    public class ProductDto : ProductBaseDto
    {
        public BaseDto CategoryBaseDto { get; set; }
        public BaseDto BrandBaseDto { get; set; }
    }
}
