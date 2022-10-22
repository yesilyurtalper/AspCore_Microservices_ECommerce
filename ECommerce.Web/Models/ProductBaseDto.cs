using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class ProductBaseDto : BaseDto
    {
        public string ImageUrl { get; set; }
        [Range(1,1000)]
        public double Price { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
