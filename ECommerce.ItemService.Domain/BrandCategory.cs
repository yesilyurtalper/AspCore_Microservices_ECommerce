
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.ItemService.Domain;

public class BrandCategory
{
    [ForeignKey(nameof(Brand))]
    public int BrandId { get; set; }
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public Brand Brand { get; set; }

    public Category Category { get; set; }
}
