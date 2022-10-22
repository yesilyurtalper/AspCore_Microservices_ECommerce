using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.APIs.ItemAPI.Models
{
    public class Product : BaseModel
    {
        public string ImageUrl { get; set; }      
        [Range(1,1000)]
        public double Price { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
