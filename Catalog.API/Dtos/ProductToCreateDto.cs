namespace Catalog.API.Dtos;

public class ProductToCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }
    public int Rating { get; set; }
    public int CategoryId { get; set; }
    public IEnumerable<int> Locations { get; set; }
}
