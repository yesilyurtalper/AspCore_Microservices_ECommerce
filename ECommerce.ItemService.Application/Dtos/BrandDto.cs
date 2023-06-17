
namespace ECommerce.ItemService.Application.Dtos;

public class BrandDto : BaseDto
{
    public List<ProductBaseDto>? ProductBaseDtos { get; set; }

    public List<BaseDto>? CategoryBaseDtos { get; set; }

    public List<BCBaseDto>? BCBaseDtos { get; set; }
}
