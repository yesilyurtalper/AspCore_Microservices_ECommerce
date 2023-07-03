using FluentValidation;

namespace ECommerce.ItemService.Application.DTOs.Validation;

public class BaseDtoValidator: AbstractValidator<BaseDto>
{
    public BaseDtoValidator()
    {
        RuleFor(p => p.Name).
            Cascade(CascadeMode.Stop).
            NotEmpty().WithMessage("{PropertyName} should not be empty").
            Length(4, 25);

        RuleFor(p => p.Description).Length(0, 1000);
    }
}
