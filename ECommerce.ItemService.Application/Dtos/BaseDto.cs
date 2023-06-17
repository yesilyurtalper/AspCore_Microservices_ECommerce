using System.ComponentModel.DataAnnotations;

namespace ECommerce.ItemService.Application.Dtos;

public class BaseDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}
