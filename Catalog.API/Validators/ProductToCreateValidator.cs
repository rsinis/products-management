using Catalog.API.Dtos;
using FluentValidation;
using System.Net;

namespace Catalog.API.Validators;

public class ProductToCreateValidator : AbstractValidator<ProductToCreateDto>
{
    public ProductToCreateValidator()
    {
        RuleFor(product => product.Name).NotEmpty().MaximumLength(50);
        RuleFor(product => product.Description).NotEmpty().MinimumLength(150);
        RuleFor(product => product.ImageUrl).NotEmpty().MaximumLength(250);
        RuleFor(product => product.CategoryId).NotEmpty();
        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image URL is required.")
            .MustAsync(BeAValidUrl).WithMessage("Please enter a valid image URL.");
    }

    private async Task<bool> BeAValidUrl(string url, System.Threading.CancellationToken cancellationToken)
    {
        Uri uriResult;
        bool isUrl = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        if (isUrl)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url, cancellationToken);

                    if (response.IsSuccessStatusCode)
                    {
                        // Check if the content type indicates an image
                        string contentType = response.Content.Headers.ContentType?.MediaType;
                        return contentType != null && contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase);
                    }
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                // URL is invalid or not accessible
                return false;
            }
        }
        return false;
    }
}
