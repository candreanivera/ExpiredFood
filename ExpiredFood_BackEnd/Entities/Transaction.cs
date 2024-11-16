using System;

namespace ExpiredFood_BackEnd.Entities;

public class Transaction
{
    public int TransactionId { get; set; }
    public int UserId { get; set; }
    public User ?User{ get; set; }
    public DateTime Due_Date { get; set; }    
    public int CategoryId { get; set; }
    public Category ?Category { get; set; }
    public DateTime Date { get; set; }
    public string ?Observations { get; set; }
}
