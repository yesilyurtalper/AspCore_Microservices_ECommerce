using System.ComponentModel.DataAnnotations;

namespace ECommerce.ItemService.Application.DTOs;

public class ProductBaseDto : BaseDto
{
    public string? ImageUrl { get; set; }
    public double Price { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
}
