using FluentValidation;

namespace ECommerce.ItemService.Application.DTOs.Validation;

public class ProductBaseDtoValidator: AbstractValidator<ProductBaseDto>
{
    public ProductBaseDtoValidator()
    {
        RuleFor(p => p.Price).
            Cascade(CascadeMode.Stop).
            NotEmpty().WithMessage("{PropertyName} should not be empty").
            ExclusiveBetween(1, 100);

        RuleFor(p => p.BrandId).NotEmpty();

        RuleFor(p => p.CategoryId).NotEmpty();
    }
}
