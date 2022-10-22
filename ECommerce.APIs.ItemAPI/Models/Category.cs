using System.ComponentModel.DataAnnotations;

namespace ECommerce.APIs.ItemAPI.Models
{
    public class Category : BaseModel
    {
        public List<Product> Products { get; set; }

        public List<BrandCategory> BrandCategories { get; set; }
    }
}
