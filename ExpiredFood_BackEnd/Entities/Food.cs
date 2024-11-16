using System;

namespace ExpiredFood_BackEnd.Entities;

public class Food
{
    public int FoodId { get; set; }
    public string ?Name { get; set; }
    public string ?Brand { get; set; }
    public int CategoryId { get; set; }
    public Category ?Category { get; set; }
    //relationship 1 to many with Transaction
    public ICollection<Transaction> ?Transactions { get; set; }
}
