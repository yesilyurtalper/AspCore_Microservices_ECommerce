using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class BrandDto : BaseDto
    {
        public List<ProductBaseDto> ProductBaseDtos { get; set; }

        public List<BaseDto> CategoryBaseDtos { get; set; }

        public List<BCBaseDto> BCBaseDtos { get; set; }

        public List<int> CategoryIdAdd { get; set; }

        public List<int> CategoryIdRemove { get; set; }
    }
}
