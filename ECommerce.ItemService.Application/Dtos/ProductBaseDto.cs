using System.ComponentModel.DataAnnotations;

namespace ECommerce.ItemService.Application.Dtos;

public class ProductBaseDto : BaseDto
{
    public string? ImageUrl { get; set; }
    [Required]
    [Range(1, 1000)]
    public double Price { get; set; }
    [Required]
    public int BrandId { get; set; }
    [Required]
    public int CategoryId { get; set; }
}
