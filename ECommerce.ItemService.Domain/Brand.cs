
namespace ECommerce.ItemService.Domain;

public class Brand : BaseItem
{
    public List<Product> Products { get; set; }

    public List<BrandCategory> BrandCategories { get; set; }
}
