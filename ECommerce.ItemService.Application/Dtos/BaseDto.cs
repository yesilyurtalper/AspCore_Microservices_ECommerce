using System.ComponentModel.DataAnnotations;

namespace ECommerce.ItemService.Application.Dtos;

public class BaseDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(1000)]
    public string Description { get; set; }

    public DateTime DateCreated { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime DateModified { get; set; }
    public string? ModifiedBy { get; set; }
}
