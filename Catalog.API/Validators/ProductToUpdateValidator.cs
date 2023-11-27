using Catalog.API.Dtos;
using FluentValidation;

namespace Catalog.API.Validators;

public class ProductToUpdateValidator : AbstractValidator<ProductToUpdateDto>
{
    public ProductToUpdateValidator()
    {
        RuleFor(product => product.Id).NotEmpty();
        RuleFor(product => product.Name).NotEmpty().MaximumLength(50);
        RuleFor(product => product.Description).NotEmpty().MinimumLength(150);
        RuleFor(product => product.ImageUrl).NotEmpty().MaximumLength(250);
        RuleFor(product => product.CategoryId).NotEmpty();
    }
}
