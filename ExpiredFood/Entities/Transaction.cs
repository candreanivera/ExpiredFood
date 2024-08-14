using System;

namespace ExpiredFood.Entities;

public class Transaction
{
    public int TransactionId { get; set; }
    public int User_Id { get; set; }
    public User ?User{ get; set; }
    public DateTime Due_Date { get; set; }    
    public int FoodId { get; set; }
    public Food ?Food { get; set; }
    public DateTime Timestamp { get; set; }
    public string ?Observations { get; set; }
}
