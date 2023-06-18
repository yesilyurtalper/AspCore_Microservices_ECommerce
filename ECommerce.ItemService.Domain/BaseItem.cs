using System.ComponentModel.DataAnnotations;

namespace ECommerce.ItemService.Domain;

public class BaseItem
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name  { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public DateTime DateCreated { get; set; }
    [Required]
    [MaxLength(100)]
    public string CreatedBy { get; set; } = string.Empty;
    [Required]
    public DateTime DateModified { get; set; }
    [Required]
    [MaxLength(100)]
    public string ModifiedBy { get; set; } = string.Empty;
}
