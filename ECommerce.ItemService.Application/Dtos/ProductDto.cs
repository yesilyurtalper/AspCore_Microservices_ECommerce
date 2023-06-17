namespace ECommerce.ItemService.Application.Dtos;

public class ProductDto : ProductBaseDto
{
    public BaseDto CategoryBaseDto { get; set; }
    public BaseDto BrandBaseDto { get; set; }
}
