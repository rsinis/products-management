namespace Catalog.API.Entities;

public class Review
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime? DateModification { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}