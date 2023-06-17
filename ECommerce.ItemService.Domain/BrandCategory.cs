
namespace ECommerce.ItemService.Domain;

public class BrandCategory
{
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public Brand Brand { get; set; }

    public Category Category { get; set; }
}
