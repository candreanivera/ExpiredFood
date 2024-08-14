using System;

namespace ExpiredFood.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public ICollection<Food> ?Foods { get; set; }
}
