using System.ComponentModel.DataAnnotations;

namespace ECommerce.ItemService.Application.DTOs;

public class BaseDto
{
    public int Id { get; set; }
    public string Name  { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime DateModified { get; set; }
    public string ModifiedBy { get; set; } = string.Empty;
}
