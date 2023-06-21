using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class BrandDto : BaseDto
    {

        public List<int> CategoryIdAdd { get; set; }

        public List<int> CategoryIdRemove { get; set; }
    }
}
