namespace Catalog.API.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime? DateModification { get; set; }
}
