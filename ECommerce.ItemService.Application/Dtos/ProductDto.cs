namespace ECommerce.ItemService.Application.DTOs;

public class ProductDto : ProductBaseDto
{
    public BaseDto? CategoryBaseDto { get; set; }
    public BaseDto? BrandBaseDto { get; set; }
}
