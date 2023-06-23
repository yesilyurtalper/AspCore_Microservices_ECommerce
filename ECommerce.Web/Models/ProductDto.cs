using System.ComponentModel.DataAnnotations;

namespace ECommer.ItemUI.Models
{
    public class ProductDto : ProductBaseDto
    {
        public BaseDto CategoryBaseDto { get; set; }
        public BaseDto BrandBaseDto { get; set; }
    }
}
