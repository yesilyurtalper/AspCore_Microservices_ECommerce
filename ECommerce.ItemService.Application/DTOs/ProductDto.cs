namespace ECommerce.ItemService.Application.DTOs;

public class ProductDto : BaseDto
{
    public string? ImageUrl { get; set; }
    public double Price { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public BaseDto? CategoryBaseDto { get; set; }
    public BaseDto? BrandBaseDto { get; set; }
}
