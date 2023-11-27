using Catalog.API.Dtos;
using FluentValidation;

namespace Catalog.API.Validators;

public class ProductToCreateValidator : AbstractValidator<ProductToCreateDto>
{
    public ProductToCreateValidator()
    {
        //RuleFor(book => book.Isbn)
        //    .Matches(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")
        //    .WithMessage("Value was not a valid ISBN-13");

        RuleFor(product => product.Name).NotEmpty().MaximumLength(50);
        RuleFor(product => product.Description).NotEmpty().MinimumLength(150);
        RuleFor(product => product.ImageUrl).NotEmpty().MaximumLength(250);
        RuleFor(product => product.CategoryId).NotEmpty();
    }
}
