namespace Catalog.API.Dtos;

public class ProductToReturnDto
{
    public ProductToReturnDto()
    {
        Locations = new HashSet<LocationDto>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }
    public int Rating { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public IEnumerable<LocationDto> Locations { get; set; }
}
