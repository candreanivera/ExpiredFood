using System;

namespace ExpiredFood.Frontend.Models;

public class TransactionDetails
{
    public int TransactionId { get; set; }
    public int UserId { get; set; }
    public string ?UserName{ get; set; }
    public DateTime Due_Date { get; set; }    
    public int FoodId { get; set; }
    public string ?FoodName { get; set; }
    public DateTime Date { get; set; }
    public string ?Observations { get; set; }
}
