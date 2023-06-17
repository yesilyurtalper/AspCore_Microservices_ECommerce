using System.ComponentModel.DataAnnotations;

namespace ECommerce.ItemService.Domain;
public class Product : BaseItem
{
    public string ImageUrl { get; set; }
    [Range(1, 1000)]
    public double Price { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
