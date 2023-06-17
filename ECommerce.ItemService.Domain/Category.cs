
namespace ECommerce.ItemService.Domain;

public class Category : BaseItem
{
    public List<Product> Products { get; set; }

    public List<BrandCategory> BrandCategories { get; set; }
}
