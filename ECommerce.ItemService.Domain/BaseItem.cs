using System.ComponentModel.DataAnnotations;

namespace ECommerce.ItemService.Domain;

public class BaseItem
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}
