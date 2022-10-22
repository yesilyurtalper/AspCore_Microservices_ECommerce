using System.ComponentModel.DataAnnotations;

namespace ECommerce.APIs.ItemAPI.Models
{
    public class BrandDto : BaseDto
    {
        public List<ProductBaseDto> ProductBaseDtos { get; set; }

        public List<BaseDto> CategoryBaseDtos { get; set; }

        public List<BCBaseDto> BCBaseDtos { get; set; }
    }
}
