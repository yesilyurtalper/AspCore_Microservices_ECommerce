using System.ComponentModel.DataAnnotations;

namespace ECommer.ItemUI.Models
{
    public class BrandDto : BaseDto
    {

        public List<int> CategoryIdAdd { get; set; }

        public List<int> CategoryIdRemove { get; set; }
    }
}
