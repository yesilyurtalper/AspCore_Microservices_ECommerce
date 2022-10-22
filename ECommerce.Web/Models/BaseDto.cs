using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class BaseDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
