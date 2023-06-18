
namespace ECommerce.ItemService.Domain;

public class Brand : BaseItem
{
    public ICollection<Product>? Products { get; set; }

    public ICollection<BrandCategory>? BrandCategories { get; set; }
}
