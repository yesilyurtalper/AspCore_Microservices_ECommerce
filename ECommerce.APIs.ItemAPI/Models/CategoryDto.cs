using System.ComponentModel.DataAnnotations;

namespace ECommerce.APIs.ItemAPI.Models
{
    public class CategoryDto : BaseDto
    {
        public List<ProductBaseDto> ProductBaseDtos { get; set; }

        public List<BaseDto> BrandBaseDtos { get; set; }

        public List<BCBaseDto> BCBaseDtos { get; set; }
    }
}
