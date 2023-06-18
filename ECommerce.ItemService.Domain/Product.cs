using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.ItemService.Domain;
public class Product : BaseItem
{
    public string? ImageUrl { get; set; }
    [Range(1, 1000)]
    public double Price { get; set; }
    [ForeignKey(nameof(Brand))]
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
