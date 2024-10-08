using System;
namespace ExpiredFood.Frontend.Models;

public class TransactionDetails
{
    public int TrxId { get; set; }
    public int UserID { get; set; }
    public string ?UserName{ get; set; }
    public DateTime Due_Date { get; set; }    
    public int CategoryId { get; set; }
    public string ?CategoryName { get; set; }
    public DateTime Timestamp { get; set; }
    public string ?Observations { get; set; }
}
