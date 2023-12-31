﻿namespace Catalog.API.Entities;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime? DateModification { get; set; }
}
