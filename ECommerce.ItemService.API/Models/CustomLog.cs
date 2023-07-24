using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.API.Models
{
    public class CustomLog
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public ResponseDtoBase Result { get; set; }
        public DateTime? Created { get; set; }  = DateTime.Now;
        public string User { get; set; }
    }
}
