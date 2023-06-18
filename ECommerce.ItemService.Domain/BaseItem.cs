using System.ComponentModel.DataAnnotations;

namespace ECommerce.ItemService.Domain;

public class BaseItem
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime DateModified { get; set; }
    public string? ModifiedBy { get; set; }
}
