
namespace Catalog.API.Entities;

public class Product : ISoftDelete
{
    public Product()
    {
        Reviews = new HashSet<Review>();
        ProductLocations = new HashSet<ProductLocation>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }
    public int[] Ratings { get; set; }

    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    public DateTime DateCreation { get; set; }
    public DateTime? DateModification { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<ProductLocation> ProductLocations { get; set; }
}
