using System;
using ExpiredFood.Frontend.Models;

namespace ExpiredFood.Frontend.Clients;

public class TransactionsClient
{
    private TransactionDetails[] transactions =
    [
        new(){
            TransactionId = 1,
            UserId = 2,
            UserName = "Cristina",
            Due_Date = new DateTime(2024,09,18),  
            FoodId = 2,
            FoodName = "Heladito de piña ñam",
            Date = new DateTime(2024,09,18),
            Observations = "Test Transaction"
        }
    
    ];


    public TransactionDetails[] GetTransactions()
    => [..transactions];
}
