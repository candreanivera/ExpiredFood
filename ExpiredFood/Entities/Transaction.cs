using System;

namespace ExpiredFood.Entities;

public class Transaction
{
    int Trx_Id { get; set; }
    int User_Id { get; set; }
    DateTime Due_Date { get; set; }    
    int Food_Id { get; set; }
    DateTime Timestamp { get; set; }
    string ?Observations { get; set; }
}
