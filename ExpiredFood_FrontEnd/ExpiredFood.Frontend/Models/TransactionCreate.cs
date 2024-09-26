using System;
using System.Text.Json.Serialization;
using ExpiredFood.Frontend.Converters;

namespace ExpiredFood.Frontend.Models;

public class TransactionCreate
{   
   
    public int UserId{ get; set; }

    public DateTime Due_Date { get; set; }   
   
    public int CategoryId { get; set; }
    public DateTime DateTime { get; set; }
    public string ?Observations { get; set; }
}
