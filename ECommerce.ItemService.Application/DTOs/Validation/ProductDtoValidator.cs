using FluentValidation;

namespace ECommerce.ItemService.Application.DTOs.Validation;

public class ProductDtoValidator: AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        Include(new BaseDtoValidator());

        RuleFor(p => p.Price).
            Cascade(CascadeMode.Stop).
            NotEmpty().WithMessage("{PropertyName} should not be empty").
            ExclusiveBetween(1, 100);

        RuleFor(p => p.BrandId).NotEmpty();

        RuleFor(p => p.CategoryId).NotEmpty();
    }
}
